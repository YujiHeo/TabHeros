using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataBase", menuName = "NewPlayer")]
public class PlayerDataBase : ScriptableObject
{
    public int ATK;
    public int crit;
    public int gainGold;
    public int upgradePoint;
    public float autoAttackRate;
}
