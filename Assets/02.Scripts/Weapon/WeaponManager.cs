using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.UIElements.ToolbarMenu;

public class WeaponManager : Singleton<WeaponManager>
{


    /*
    public void AddItem(WeaponType weapon, int number)
    {
        string assetName = $"{weapon.ToString()} {number}";
        WeaponData weaponData = Resources.Load<WeaponData>(assetName);

        if (weaponData == null)
        {
            Debug.Log("������ �����͸� �ҷ����µ� �����ϼ̽��ϴ�.");
            return;
        }

        UIInventory.instance.AddItem(weaponData);
    }
    */
}
