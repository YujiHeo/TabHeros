using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponList", menuName = "ScriptableObjects/WeaponList")]

public class WeaponList : ScriptableObject
{
    private WeaponData weaponData;

    public List<WeaponData> weaponList = new List<WeaponData>();

    //public Dictionary<int, WeaponData> weaponDic = new Dictionary<int, WeaponData> ();
    public void Start()
    {
       
    }

    public void GetWeapon()
    {
        for (int i = 1; i < 6; i++)
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


