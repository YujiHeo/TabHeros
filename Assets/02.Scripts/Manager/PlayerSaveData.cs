using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveData  // 세이브 총대장
{
    public PlayerSaveData playerSaveData = new PlayerSaveData();
    public StageSaveData stageSaveData = new StageSaveData();
    public WeaponSaveData weaponSaveData = new WeaponSaveData();
    public HeroSaveData heroSaveData = new HeroSaveData();
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
        // 장착 여부를 플레이어에서 관리 
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
public class WeaponSaveData  // 리스트 형태가 되어야 됨 (각 무기가)
{
    // 무기 장착상황
    // 초기화 값을 -1로 설정하면 아예 가지고 있지 않은 상태. 
    public int weaponLevel;
    public int weaponAbility;  // 저장할 필요가 없음. 로드한 다음에 계산해서 써야 됨. 
    public int ownUpgradePoints; // 저장할 필요가 없음. 마찬가지로 계산해서 써야 됨.

    public void SaveFromWeaponData(WeaponData weaponData)
    {
        weaponLevel = weaponData.level;
        weaponAbility = weaponData.ability;
        ownUpgradePoints = weaponData.ownUpgradePoint;
    }

}

[Serializable]
public class HeroSaveData
{
    public bool[] isUnlocked = new bool[5];
    public int[] level = new int[5];
}

