using System;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    //재화
    public int gold;
    public int upgradePoints;
    // 레벨
    public int atkLevel;
    public int critLevel;
    public int critDamageLevel;
    public int goldGainLevel;

    public PlayerSaveData()
    {
        gold = 0;
        upgradePoints = 0;

        atkLevel = 1;
        critLevel = 1;
        critDamageLevel = 1;
        goldGainLevel = 1;
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

    public StageSaveData()
    {
        currentStage = 0;
        killCount = new Dictionary<int, int>();
        clearStage = 0;
    }
}

[Serializable]
public class WeaponSaveData
{
    // 무기 장착상황
    public int weaponLevel;
    public int weaponAbility;
    public int ownUpgradePoints;

    public void SaveFromWeaponData(WeaponData weaponData)
    {
        weaponLevel = weaponData.level;
        weaponAbility = weaponData.ability;
        ownUpgradePoints = weaponData.ownUpgradePoint;
    }

    public WeaponSaveData()
    {
        
    }
}

[System.Serializable]
public class HeroSaveData
{
    public bool[] isUnlocked;
    public int[] level;

    public HeroSaveData()
    {
        int heroCount = 5; 
        isUnlocked = new bool[heroCount];
        level = new int[heroCount];

        
        for (int i = 0; i < heroCount; i++)
        {
            isUnlocked[i] = false;
            level[i] = 0;
        }
    }
}


