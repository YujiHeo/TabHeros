using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    ATKUP
}

// 리턴 뭐뭐 메서드를 만들고 level은 별도로 저장 , level에 따라서 어빌리티나 업그레이드 포인트 갱신

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponData : ScriptableObject
//변동값이 있을 땐 SO를 안쓰는것이 좋다.
{
    [Header("Info")]
    public string name;

    public Sprite Icon;

    public int level;  // 변하는 녀석에서 가져와야 됨 
    public int ability;

    public int ownUpgradePoint;
    public int id;
}