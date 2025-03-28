using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    [SerializeField]private PlayerDataBase playerData;
    
    // PlayerData.GetStatLevel(스탯) 을 사용해서 스텟 레벨을 받아 올 수 있습니다
    public int GetStatLevel(PlayerStatType statType)
    {
        PlayerStat stat = playerData.stats.Find(s => s.statType == statType);
        return stat != null ? stat.level : 1; // 기본 레벨 1
    }
    
    public float GetStatValue(PlayerStatType statType)
    {
        int level = GetStatLevel(statType);

        return statType switch
        {
            PlayerStatType.Atk => (level - 1) * 10 + 10,
            PlayerStatType.Crit => (level - 1) * 0.1f + 5,
            PlayerStatType.CritDamage => (level - 1) * 10 + 100,
            PlayerStatType.GoldGain => (level - 1) * 10 + 100,
            _ => 0
        };
    }
    
    // playerData.UpdateStat(stat, currentLevel + 1); 처럼 스텟 관련 업데이트가 필요할 때, 이런식으로 사용하면됩니다.
    public void UpdateStat(PlayerStatType statType, int newLevel)
    {
        PlayerStat stat = playerData.stats.Find(s => s.statType == statType);
        if (stat != null)
        {
            stat.level = newLevel;
        }
        else
        {
            playerData.stats.Add(new PlayerStat { statType = statType, level = newLevel });
        }
    }
}
