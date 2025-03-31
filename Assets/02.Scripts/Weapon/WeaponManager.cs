using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.UIElements.ToolbarMenu;

public class WeaponManager : Singleton<WeaponManager>
{
    private WeaponData weaponData;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            AddItem(WeaponType.ATKUP, i);
        }

    }
    public void AddItem(WeaponType weapon, int number)
    {
        string assetName = $"{weapon.ToString()} {number}";
        WeaponData weaponData = Resources.Load<WeaponData>(assetName);

        if (weaponData == null)
        {
            Debug.Log("아이템 데이터를 불러오는데 실패하셨습니다.");
            return;
        }

        UIInventory.instance.AddItem(weaponData);
    }
}
