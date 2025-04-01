using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveData  // 세이브 총대장
{
    public PlayerSaveData playerSaveData = new PlayerSaveData();
    public StageSaveData stageSaveData = new StageSaveData();
    public WeaponSaveData weaponSaveData = new WeaponSaveData();
   // public HeroSaveData heroSaveData = new HeroSaveData();
}

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

}

[Serializable]
public class StageSaveData
{
    // 스테이지 진행 상황
    public int currentStage;
    public Dictionary<int, int> killCount = new Dictionary<int, int>();
    public int clearStage;

    public void SaveFromStageManager(StageManager stageManager)
    {
        currentStage = stageManager.currentStage;
        killCount = stageManager.killCount;
        clearStage = stageManager.clearStage;
    }
}

[Serializable]
public class WeaponSaveData
{
    // 무기 장착상황
    public int weaponLevel;
    public int weaponAbility;
    public int upgradePoints;
    //  이 upgaradePoints를 지금은 WeaponData의 값으로 추가해주고 있는데,
    //  player.upgradePoints에 보내던지 중앙관리 해야하는 것 아닌지?

    public void SaveFromWeaponData(WeaponData weaponData)
    {
        weaponLevel = weaponData.level;
        weaponAbility = weaponData.ability;
        upgradePoints = weaponData.ownUpgradePoint;
    }

}

//[Serializable]
//public class HeroSaveData
//{
//    // 앞으로 저장될 영웅 관련 데이터
//}

