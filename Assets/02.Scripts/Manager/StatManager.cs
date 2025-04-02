using System;

public class StatManager : Singleton<StatManager>
{
    public static event Action OnStatUpdated;
    private PlayerSaveData playerData;
   
    private void Start()
    {
        playerData = SaveLoadManager.instance.playerData;
    }

    // PlayerDataBase에 존재하는 Playerstat에서 스탯을 가져오고
    public int GetStatLevel(PlayerStatType statType)
    {
        PlayerSaveData data = SaveLoadManager.instance.playerData;
        return statType switch
        {
            PlayerStatType.Atk => data.atkLevel,
            PlayerStatType.Crit => data.critLevel,
            PlayerStatType.CritDamage => data.critDamageLevel,
            PlayerStatType.GoldGain => data.goldGainLevel
        };
    }
    
    public float SetStatValue(PlayerStatType statType)
    {
        int level = GetStatLevel(statType);
        PlayerSaveData data = SaveLoadManager.instance.playerData;

        return statType switch
        {
            PlayerStatType.Atk => (level- 1) * 10 + 10,
            PlayerStatType.Crit => (level - 1) * 0.1f + 5,
            PlayerStatType.CritDamage => (level - 1) * 10 + 100,
            PlayerStatType.GoldGain => (level - 1) * 10 + 100,
        };
    }

    // 스탯 최신화
    public void UpdateStat(PlayerStatType statType, int newLevel)
    {
        // SaveLoadManager.instance.playerData가 PlayerSaveData 객체라고 가정
        PlayerSaveData data = SaveLoadManager.instance.playerData;

        switch (statType)
        {
            case PlayerStatType.Atk:
                data.atkLevel = newLevel;
                break;
            case PlayerStatType.Crit:
                data.critLevel = newLevel;
                break;
            case PlayerStatType.CritDamage:
                data.critDamageLevel = newLevel;
                break;
            case PlayerStatType.GoldGain:
                data.goldGainLevel = newLevel;
                break;
        }

        OnStatUpdated?.Invoke();
        
        SaveLoadManager.instance.SaveAllData();
    }
    
}
