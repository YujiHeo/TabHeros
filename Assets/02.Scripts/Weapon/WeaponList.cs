using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponList", menuName = "ScriptableObjects/WeaponList")]

public class WeaponList : ScriptableObject
{
    private WeaponData weaponData;

    public List<WeaponData> weaponList = new List<WeaponData>(); //Slot�� ������� �Ҵ��� �뵵�� List ����.

    public void GetWeapon()
    {
        for (int i = 1; i < 6; i++) //�ε��� �ѹ��� 1001���� ����.
        {
            WeaponData weaponData100n = GetWeaponData(1000 + i);

            UIInventory.instance.AddItem(weaponData100n);
        }
    }

    public WeaponData GetWeaponData(int id)
    {
        WeaponData weaponData = weaponList.Find(Data => Data.id == id);
        WeaponData cloneData = Instantiate(weaponData); //������ ����

        return cloneData;
    }
}


