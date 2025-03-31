using System;
using System.Collections.Generic;

public class SaveData // 일종의 세이브 대장. 초기화 기능 담당
{
    public PlayerSaveData playerCoreData = new PlayerSaveData();
    public StatCoreData statCoreData = new StatCoreData();
    public WeaponData weaponCoreData = new WeaponData();
    // public HeroCoreData heroCoreData 히어로 자동 공격 세이브 기능
    //public TrophyCoreData trophyCoreData 업적 세이브 기능

    public T GetData<T>(ref T data) where T : class, new()
    {
        return data ?? new T();
    }

    public void SetData<T>(T data) where T : class
    {
        if (typeof(T) == typeof(PlayerSaveData))
        {
            playerCoreData = data as PlayerSaveData;
        }
        else if (typeof(T) == typeof(StatCoreData))
        {
            statCoreData = data as StatCoreData;
        }
        else if (typeof(T) == typeof(WeaponData))
        {
            weaponCoreData = data as WeaponData;
        }

    }

}

//public int currentStage;   // 현재 스테이지
//public List<int> completedStages = new List<int>();  // 완료된 스테이지 리스트

[Serializable]
public class PlayerSaveData
{
    public int atk;
    public double crit;
    public int critDamage;
    public int gold;
    public int upgradePoints;
    public double goldGainRate;

    public void SaveFromPlayer(Player player)
    {
        atk = player.atk;
        crit = player.crit;
        critDamage = player.critDamage;
        gold = player.gold;
        goldGainRate = player.goldGainRate;
        upgradePoints = player.upgradePoints;
    }
}

    [Serializable]
public class StatCoreData  // 스탯 관련 저장데이터
{
    public int atkLevel;
    public int critLevel;
    public int critDamageLevel;
    public int gainGoldLevel;
    public int atk;
    public double crit;
    public int critDamage;
}

[Serializable]
public class WeaponCoreData
{
    public int weaponLevel;                // 무기 레벨
    public int weaponAbility;              // 무기 능력치
    public int weaponUpgradePoints;        // 무기 업그레이드 포인트
    // public List<WeaponList> weaponlist; // 무기 리스트를 저장

}

// public class TrophyCoreData

