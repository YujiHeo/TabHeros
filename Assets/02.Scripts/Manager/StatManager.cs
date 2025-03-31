using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    [SerializeField]private PlayerDataBase playerData;
    public static event Action OnStatUpdated;
    
    // PlayerDataBase에 존재하는 Playerstat에서 스탯을 가져오고
    public int GetStatLevel(PlayerStatType statType)
    {
        PlayerStat stat = playerData.stats.Find(s => s.statType == statType);
        return stat != null ? stat.level : 1;
    }
    
    public float SetStatValue(PlayerStatType statType)
    {
        int level = GetStatLevel(statType); // 가져온 레벨을 여기에서 타입에 맞춰서 계산하여, 스탯을 반환  

        return statType switch
        {
            PlayerStatType.Atk => (level - 1) * 10 + 10,
            PlayerStatType.Crit => (level - 1) * 0.1f + 5,
            PlayerStatType.CritDamage => (level - 1) * 10 + 100,
            PlayerStatType.GoldGain => (level - 1) * 10 + 100,
            _ => 0
        };
    }

    // 스탯 최신화
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
        OnStatUpdated?.Invoke();
    }
}
