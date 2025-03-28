using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    private WeaponData weaponData;

    void Start()
    {
        AddItem(WeaponType.ATKUP);
    }

    public void AddItem(WeaponType weapon)
    {
        WeaponData weaponData = Resources.Load<WeaponData>(weapon.ToString());

        if (weaponData == null)
        {
            Debug.Log("������ �����͸� �ҷ����µ� �����ϼ̽��ϴ�.");
            return;
        }

        UIInventory.instance.AddItem(weaponData);
    }
}
