using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
    public Dictionary<int, int> killCount = new Dictionary<int, int>();  //  뉴턴소프트제이슨 다운받으면 딕셔너리를 제이슨에 저장 가능함
    public int clearStage;

    public void SaveFromStageManager(StageManager stageManager)
    {
        currentStage = stageManager.currentStage;
        killCount = stageManager.killCount;
        clearStage = stageManager.clearStage;
    }
}

[Serializable]
public class WeaponSaveData  // 하나 하나 5개 다 넣어주는 방식으로. 리스트나 딕셔너리 형태가 되어야 됨 (각 무기의 개수만큼 다 저장되어야) // 다른 플레이어 스탯 데이터에 무기 리스트를 저장
{
    // 값이 저장되는 순간 
    // 리스트 넣어주면
    // 무기 장착상황
    // 초기화 값을 -1로 설정하면 아예 가지고 있지 않은 상태로 인식이 됨.
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

