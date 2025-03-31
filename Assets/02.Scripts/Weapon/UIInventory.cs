using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIInventory : Singleton<UIInventory>
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    [SerializeField] private Image CurrentWeapon;

    static Player player;

    private List<WeaponSlot> slotList = new List<WeaponSlot>();

    private int slotIndex = 0;

    private WeaponData weaponData;
    private WeaponSlot weaponSlot;


    protected override void Awake()
    {
        base.Awake();

        player = FindObjectOfType<Player>();

        InitInventoryUI();
    }

    public void InitInventoryUI()
    {
        int slotCount = 5;

        for (int i = 0; i < slotCount; i++) // 5번 반복됨
        {
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

    public void WeaponUpgrade(Player player, WeaponData newWeapon) //무기 업그레이드
    {
        if (player.upgradePoints >= newWeapon.ownUpgradePoint)
        {
            player.upgradePoints -= newWeapon.ownUpgradePoint;

            newWeapon.level++;
            newWeapon.ability += 10;

            newWeapon.ownUpgradePoint *= 2;
        }
        else
        {
            Debug.Log("포인트가 부족합니다!");
        }
    }



    public void WeaponEquipped(WeaponSlot weaponSlot, WeaponData selectedWeapon) //무기 장착
    {
        //무기 장착 시 해당 무기 슬롯 장착 버튼 비활성화

        //weaponSlot.AlreadyEquipped();
        CurrentWeapon.sprite = selectedWeapon.Icon;

        player.atk += selectedWeapon.ability;
    }

}
