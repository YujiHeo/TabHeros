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
            Debug.Log("아이템 데이터를 불러오는데 실패하셨습니다.");
            return;
        }

        UIInventory.instance.AddItem(weaponData);
    }
}
