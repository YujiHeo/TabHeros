using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIInventory : Singleton<UIInventory>
{
    [SerializeField] public Button inventoryBtn;
    [SerializeField] public GameObject inventoryWindow;

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    //[SerializeField] private TextMeshProUGUI slotCounts;

    static Player player;

    private GameObject equippedWeapon;

    private List<WeaponSlot> slotList = new List<WeaponSlot>();

    private int slotIndex = 0;

    private WeaponData weaponData;


    protected override void Awake()
    {
        base.Awake();

        /*Button btn = inventoryBtn.GetComponent<Button>();
        btn.onClick.AddListener(OpenInventory);*/

        InitInventoryUI();
    }

    public void InitInventoryUI()
    {
        int slotCount = 5;

        for (int i = 0; i < slotCount; i++) // 5번 반복됨
        {
            Debug.Log($"슬롯 생성 중: {i}");
            GameObject newSlotObject = Instantiate(slotPrefab, slotParent); //prefab에 Instantiate 
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

        else
        {
            Debug.LogWarning("슬롯의 수를 초과했습니다.");
        }
    }

    public void OpenInventory()
    {
        inventoryWindow.SetActive(true);
    }

    public void WeaponUpgrade(WeaponData newWeapon) //무기 업그레이드
    {
        if (player.upgradePoints >= newWeapon.ownUpgradePoint)
        {
            player.upgradePoints -= newWeapon.ownUpgradePoint;

            int point = newWeapon.ownUpgradePoint;

            player.upgradePoints -= point;
            newWeapon.level ++;
            newWeapon.ability += 10;


            newWeapon.ownUpgradePoint *= 2;
        }
        else
        {
            Debug.Log("포인트가 부족합니다!");
        }
    }


    /*
    public void WeaponEquipped(WeaponData newWeapon) //무기 장착
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon);
        }

        if (equippedWeapon != null && newWeapon.weaponPrefab != null)
        {
            equippedWeapon = Instantiate(newWeapon.weaponPrefab, transform);
            weaponData = newWeapon;
        }
    }
    */
}
