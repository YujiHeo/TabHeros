using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponList", menuName = "ScriptableObjects/WeaponList")]

public class WeaponList : ScriptableObject
{
    private WeaponData weaponData;

    public List<WeaponData> weaponList = new List<WeaponData>(); //Slot에 순서대로 할당할 용도로 List 생성.

    //public Dictionary<int, WeaponData> weaponDic = new Dictionary<int, WeaponData> ();

    public void GetWeapon()
    {
        for (int i = 1; i < 6; i++) //인덱스 넘버는 1001부터 시작.
        {
            WeaponData weaponData100n = GetWeaponData(1000 + i);

            UIInventory.instance.AddItem(weaponData100n);
        }
    }

    public WeaponData GetWeaponData(int id)
    {
        WeaponData weaponData = weaponList.Find(Data => Data.id == id);

        return weaponData;
    }



}


