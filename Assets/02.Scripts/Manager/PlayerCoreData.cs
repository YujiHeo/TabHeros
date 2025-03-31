using System;
using System.Collections.Generic;

// Singleton<T> 적용하겠습니다.

public class SaveData // 일종의 세이브 대장. 초기화 기능 담당
{
    public PlayerCoreData playerCoreData = new PlayerCoreData();
    public StatCoreData statCoreData = new StatCoreData();
    public WeaponData weaponCoreData = new WeaponData();
   // public HeroCoreData heroCoreData 히어로 자동 공격 세이브 기능
    //public TrophyCoreData trophyCoreData 업적 세이브 기능
}

[Serializable]
public class PlayerCoreData
{
    // 기본적인 유저 진행 상황
    public int currentStage;                // 현재 스테이지
    public List<int> completedStages = new List<int>();  // 완료된 스테이지 리스트

    // 재화 보유량
    public int gold; // 현재 골드 보유량
    public double goldGainRate;  // 골드 획득량
    public int upgradePoints;  // 장비 업그레이드할 때 쓰는 포인트
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

