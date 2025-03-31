using System;
using System.Collections.Generic;

[Serializable]
public class PlayerSaveData
{
    // 재화 보유량
    public int gold;
    public double goldGainRate;
    public int upgradePoints;

    // 스탯 정보
    public int atk;
    public double crit;
    public int critDamage;

    public void SaveFromPlayer(Player player)
    {
        gold = player.gold;
        goldGainRate = player.goldGainRate;
        upgradePoints = player.upgradePoints;
        atk = player.atk;
        crit = player.crit;
        critDamage = player.critDamage;
    }

    // 스테이지 진행 상황
    public int currentStage;
    public Dictionary<int, int> killCount = new Dictionary<int, int>();
    public int clearStage;

    public void SaveFromStageManager(StageManager stageManager)
    {
        //currentStage = stageManager.currentStage;
        //killCount = stageManager.killCount;
        //clearStage = stageManager.clearStage;
    }

    // 무기 정보
    public List<WeaponData> weaponDataList = new List<WeaponData>();

    public void SaveFromWeaponData(List<WeaponData> weaponDataList)
    {
        this.weaponDataList = weaponDataList;
    }

    public void Initialize()  // 값 초기화 (테스트용) 
    {
        gold = 100;
        goldGainRate = 1.0;
        upgradePoints = 10;
        atk = 10;
        crit = 5.0;
        critDamage = 50;
        currentStage = 1;
        killCount = new Dictionary<int, int>();
        clearStage = 0;
        weaponDataList = new List<WeaponData>();
    }
}


