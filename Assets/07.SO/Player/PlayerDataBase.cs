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
    [SerializeField]
    private List<PlayerStat> stats = new List<PlayerStat>
    {
        new PlayerStat { statType = PlayerStatType.Atk, level = 1 },
        new PlayerStat { statType = PlayerStatType.Crit, level = 1 },
        new PlayerStat { statType = PlayerStatType.CritDamage, level = 1 },
        new PlayerStat { statType = PlayerStatType.GoldGain, level = 1 }
    };
    
    public Func<PlayerStatType, int> GetStatLevel => statType =>
    {
        PlayerStat stat = stats.Find(s => s.statType == statType);
        return stat != null ? stat.level : 0;
    };
    
    public void UpdateStat(PlayerStatType statType, int newLevel)
    {
        PlayerStat stat = stats.Find(s => s.statType == statType);
        if (stat != null)
        {
            stat.level = newLevel;
        }
        else
        {
            stats.Add(new PlayerStat { statType = statType, level = newLevel });
        }
    }
}
