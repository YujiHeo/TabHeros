using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    ATKUP
}

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponData : ScriptableObject
{
    [Header("Info")]
    public string name;

    public Sprite Icon;

    public int level;
    public int ability;

    public int ownUpgradePoint; 

    //public GameObject weaponPrefab;
}
