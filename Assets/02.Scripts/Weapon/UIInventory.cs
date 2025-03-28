using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIInventory : Singleton<UIInventory>
{
    [SerializeField] public Button inventoryBtn;
    [SerializeField] public GameObject inventoryWindow;

    [SerializeField] private WeaponSlot slotPrefab;
    [SerializeField] private Transform slotParent;

    [SerializeField] private TextMeshProUGUI slotCounts;

    private GameObject equippedWeapon;

    private List<WeaponSlot> slotList = new List<WeaponSlot>();

    private int slotIndex = 0;

    private WeaponData weaponData;


    void Start()
    {
        Button btn = inventoryBtn.GetComponent<Button>();
        btn.onClick.AddListener(OpenInventory);

        InitInventoryUI();
    }

    public void InitInventoryUI()
    {
        int slotCount = 5;
        slotCounts.text = slotCount.ToString();

        for (int i = 0; i < slotCount; i++) // 5번 반복됨
        {
            Debug.Log($"슬롯 생성 중: {i}");
            WeaponSlot newSlot = Instantiate(slotPrefab, slotParent);
            slotList.Add(newSlot);
        }
    }

    public void AddItem(WeaponData weaponData)
    {
        slotList[slotIndex].SetItem(weaponData);
        slotIndex++;
    }

    public void OpenInventory()
    {
        inventoryWindow.SetActive(true);
    }

    public void WeaponUpgrade(WeaponData newWeapon) //무기 업그레이드
    {
        if (player.instance.upgradePoint >= newWeapon.ownUpgradePoint)
        {
            player.instance.upgradePoint -= newWeapon.ownUpgradePoint;

            int point = newWeapon.ownUpgradePoint;

            player.instance.upgradePoint -= point;
            newWeapon.level ++;
            newWeapon.ability += 10;


            newWeapon.ownUpgradePoint *= 2;
        }
        else
        {
            Debug.Log("포인트가 부족합니다!");
        }
    }



    public void WeaponEquipped(WeaponData newWeapon) //무기 장착
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon);
        }

        if (equippedWeapon != null && newWeapon.weaponPrefab != null)
        {
            equippedWeapon = Instantiate(newWeapon.weaponPrefab, transform);
            newWeapon.weaponPrefab.SetActive(true); //현재 장착 중인 WeaponImage 아이콘을 만들기 위한 기능
            weaponData = newWeapon;
        }
    }
}
