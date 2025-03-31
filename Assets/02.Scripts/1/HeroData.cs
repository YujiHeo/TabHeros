using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroData", menuName = "Hero System/Hero Data")]
public class HeroData : ScriptableObject
{
    public int id;
    public string heroName;
    public Sprite heroIcon;
    public int baseDamage;
    public int unlockPrice;
    public GameObject heroPrefab;
    public float attackInterval;
    public bool isFlipped; //좌우반전된 히어로

    public string GWeffect;
    public string JWeffect;
    public string YJeffect;
    public string SHeffect;
    public string HYeffect;
    [HideInInspector] public bool isUnlocked;
    [HideInInspector] public int level = 1;
}
