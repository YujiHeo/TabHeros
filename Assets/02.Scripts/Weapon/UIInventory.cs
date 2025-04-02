using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UIInventory : Singleton<UIInventory>
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    [SerializeField] private Image CurrentWeapon;

    static Player player;

    private List<WeaponSlot> slotList = new List<WeaponSlot>();
    public List<WeaponData> weaponDataList = new List<WeaponData>();

    private int slotIndex = 0;

    private WeaponData weaponData;
    private WeaponSlot weaponSlot;

    private WeaponData currentEquippedWeapon;



    protected override void Awake()
    {
        base.Awake();

        player = FindObjectOfType<Player>();

        InitInventoryUI();
    }

    public void Start()
    {
        InitWeaponDataList();
        //save를 일회용으로 사용하는 방법도 있다!!
        WeaponSaveData save = SaveLoadManager.instance.weaponData;
        if (save.weaponLevel[0] != 0)
        {
            LoadWeaponSaveData(save);

        }

        RefreshSlotUI();
    }

    private void RefreshSlotUI()
    {
        foreach (var slot in slotList)
        {
            slot.RefreshUI();
        }
    }



    private void InitWeaponDataList()
    {
        foreach(var slot in slotList)
        {
            var weaponData = slot.GetWeaponData();

            weaponDataList.Add(weaponData);
        }
    }

    public void InitInventoryUI()
    {
        int slotCount = 5;

        for (int i = 0; i < slotCount; i++)
        {
            GameObject newSlotObject = Instantiate(slotPrefab, slotParent);
            WeaponSlot weaponSlot = newSlotObject.GetComponent<WeaponSlot>();
            slotList.Add(weaponSlot);
        }
    }

    public void AddItem(WeaponData weaponData)
    {
        if (slotIndex < slotList.Count)
        {
            slotList[slotIndex].SetItem(weaponData);
            slotIndex++;
        }
    }

    public void WeaponUpgrade(Player player, WeaponData newWeapon, WeaponSlot weaponSlot)
    {
        if (SaveLoadManager.instance.playerData.upgradePoints >= newWeapon.ownUpgradePoint)
        {
            SaveLoadManager.instance.playerData.upgradePoints -= newWeapon.ownUpgradePoint;

            newWeapon.level++;
            newWeapon.ability += 10;

            newWeapon.ownUpgradePoint *= 2;



            weaponSlot.RefreshUI();
            
            weaponSlot.UpdateText();

            SaveLoadManager.instance.SaveAllData();
        }
        else
        {
            UiManager.instance.ShowGoldLackWarning();
        }
    }



    public void WeaponEquipped(WeaponSlot weaponSlot, WeaponData selectedWeapon)
    {
        if (currentEquippedWeapon != null)
        {
            player.atk -= currentEquippedWeapon.ability;
        }

        currentEquippedWeapon = selectedWeapon;
        CurrentWeapon.sprite = selectedWeapon.Icon;
        player.atk += selectedWeapon.ability;

        SaveLoadManager.instance.SaveAllData();
        AchievementManager.instance.IncreaseAchievementProgress(AchievementType.Weapon , 1);
    }

    public WeaponSaveData GetWeaponSaveData()
    {
        WeaponSaveData saveData = new WeaponSaveData();

        for (int i = 0; i < weaponDataList.Count; i++)
        {
            saveData.weaponLevel[i] = weaponDataList[i].level;
            saveData.weaponAbility[i] = weaponDataList[i].ability;
            saveData.ownUpgradePoints[i] = weaponDataList[i].ownUpgradePoint;
        }

        if (CurrentWeapon.sprite != null)
        {
            Texture2D texture = CurrentWeapon.sprite.texture;
            // PNG 형식의 바이트 배열로 변환

            byte[] imageBytes = texture.EncodeToPNG();
            // Base64 문자열로 인코딩

            saveData.currentWeaponImageBase64 = Convert.ToBase64String(imageBytes);
        }
        else
        {
            saveData.currentWeaponImageBase64 = string.Empty;
        }

        return saveData;
    }

    public void LoadWeaponSaveData(WeaponSaveData saveData)
    {
        for (int i = 0; i < weaponDataList.Count; i++)
        {
            weaponDataList[i].level = saveData.weaponLevel[i];
            weaponDataList[i].ability = saveData.weaponAbility[i];
            weaponDataList[i].ownUpgradePoint = saveData.ownUpgradePoints[i];
        }

        // Base64 문자열이 저장되어 있으면 이미지 로드
        if (!string.IsNullOrEmpty(saveData.currentWeaponImageBase64))
        {
            byte[] imageBytes = Convert.FromBase64String(saveData.currentWeaponImageBase64);
            Texture2D texture = new Texture2D(2, 2); // 임시 크기, LoadImage()에서 자동으로 조정됨
            if (texture.LoadImage(imageBytes))
            {
                // 새 Sprite 생성 후 UI에 적용
                texture.filterMode = FilterMode.Point;
                Sprite loadedSprite = Sprite.Create(texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f));
                CurrentWeapon.sprite = loadedSprite;
            }
        }
    }
}