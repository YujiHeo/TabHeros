using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    // 기본적인 유저 진행 상황
    public int currentStage;                // 현재 스테이지
    public float currentCurrency;           // 보유한 재화 (골드 등)
    public List<int> completedStages = new List<int>();  // 완료된 스테이지 리스트

    // 재화 보유량
    public int gold;
    public int upgradePoints;
    public double goldGainRate;

    // 스탯 관련 변수
    public int atkLevel;
    public int critLevel;
    public int critDamageLevel;
    public int gainGoldLevel;
    public int atk;
    public double crit;
    public int critDamage;

    
    // 업그레이드 및 장비 관련
    public int weaponLevel;                // 무기 레벨
    public int weaponAbility;              // 무기 능력치
    public int weaponUpgradePoints;        // 무기 업그레이드 포인트
    public List<string> equippedItems = new List<string>();  // 장착된 장비 리스트

    // 업적 관련
    public List<string> achievementProgress; // 성취 정도 (업적 관련)

}

[Serializable]
public class Upgrade
{
    public string upgradeName;   // 업그레이드 이름
    public int level;            // 업그레이드 레벨
}
