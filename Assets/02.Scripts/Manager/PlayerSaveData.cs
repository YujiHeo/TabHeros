using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

// 전체 게임 데이터 관리 클래스
public class SaveData
{
    public PlayerSaveData playerSaveData = new PlayerSaveData();
    public StageSaveData stageSaveData = new StageSaveData();
    public WeaponSaveData weaponSaveData = new WeaponSaveData();
    public HeroSaveData heroSaveData = new HeroSaveData();
}

[Serializable]
public class PlayerSaveData
{
    //재화 정보
    public int gold;
    public int upgradePoints;

    // 플레이어 레벨 정보
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
        clearStage = -1;
    }
}

[Serializable]
public class WeaponSaveData
{
    // 무기 정보
    public bool[] isUnlocked;  // 무기 해금 여부
    public int[] weaponLevel;  // weaponLevel에 따라 ability와 upgradepoints가 달라지게끔

    public WeaponSaveData()
    {
        int weaponCount = 5; // 무기의 개수
        isUnlocked = new bool[weaponCount];
        weaponLevel = new int[weaponCount];

        for (int i = 0; i < weaponCount; i++)
        {
            isUnlocked[i] = false;
            weaponLevel[i] = 0;
        }

    }

}

[System.Serializable]
public class HeroSaveData
{
    // 영웅 잠금 상태 및 정보
    public bool[] isUnlocked;
    public int[] heroLevel;

    public HeroSaveData()
    {
        int heroCount = 5; 
        isUnlocked = new bool[heroCount];
        heroLevel = new int[heroCount];

        
        for (int i = 0; i < heroCount; i++)
        {
            isUnlocked[i] = false;
            heroLevel[i] = 0;
        }
    }
}


