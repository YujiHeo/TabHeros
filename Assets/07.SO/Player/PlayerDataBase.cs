using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerStat
{
    public PlayerStatType statType;
    public int level;
}
[Serializable][CreateAssetMenu(fileName = "PlayerDataBase", menuName = "NewPlayer")]
public class PlayerDataBase : ScriptableObject
{
    // 스탯 레벨 리스트 
    [SerializeField]
    public List<PlayerStat> stats = new List<PlayerStat>
    {
        new PlayerStat { statType = PlayerStatType.Atk, level = 1 },
        new PlayerStat { statType = PlayerStatType.Crit, level = 1 },
        new PlayerStat { statType = PlayerStatType.CritDamage, level = 1 },
        new PlayerStat { statType = PlayerStatType.GoldGain, level = 1 }
    };
}
