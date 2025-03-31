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

        for (int i = 0; i < slotCount; i++) // 5�� �ݺ���
        {
            GameObject newSlotObject = Instantiate(slotPrefab, slotParent); //prefab�� Instantiate 
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
            Debug.LogWarning("������ ���� �ʰ��߽��ϴ�.");
        }
    }

    public void WeaponUpgrade(Player player, WeaponData newWeapon) //���� ���׷��̵�
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
            Debug.Log("����Ʈ�� �����մϴ�!");
        }
    }



    public void WeaponEquipped(WeaponSlot weaponSlot, WeaponData selectedWeapon) //���� ����
    {
        //���� ���� �� �ش� ���� ���� ���� ��ư ��Ȱ��ȭ

        //weaponSlot.AlreadyEquipped();
        CurrentWeapon.sprite = selectedWeapon.Icon;

        player.atk += selectedWeapon.ability;
    }

}
