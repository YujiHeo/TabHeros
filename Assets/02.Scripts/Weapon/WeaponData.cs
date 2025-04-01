using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    ATKUP
}

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponData : ScriptableObject
//변동값이 있을 땐 SO를 안쓰는것이 좋다.
{
    [Header("Info")]
    public string name;

    public Sprite Icon;

    public int level;
    public int ability;

    public int ownUpgradePoint;
    public int id;
}
