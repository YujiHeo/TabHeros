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
    private List<PlayerStat> stats = new List<PlayerStat>
    {
        new PlayerStat { statType = PlayerStatType.Atk, level = 1 },
        new PlayerStat { statType = PlayerStatType.Crit, level = 1 },
        new PlayerStat { statType = PlayerStatType.CritDamage, level = 1 },
        new PlayerStat { statType = PlayerStatType.GoldGain, level = 1 }
    };
    
    // PlayerData.GetStatLevel(스탯) 을 사용해서 스텟 레벨을 받아 올 수 있습니다
    public Func<PlayerStatType, int> GetStatLevel => statType =>
    {
        PlayerStat stat = stats.Find(s => s.statType == statType);
        return stat != null ? stat.level : 0;
    };
    
    // playerData.UpdateStat(stat, currentLevel + 1); 처럼 스텟 관련 업데이트가 필요할 때, 이런식으로 사용하면됩니다.
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
