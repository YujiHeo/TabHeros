using System;
using System.Collections.Generic;

[Serializable]
public class PlayerSaveData
{
    // ��ȭ ������
    public int gold;
    public double goldGainRate;
    public int upgradePoints;

    // ���� ����
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

    // �������� ���� ��Ȳ
    public int currentStage;
    public Dictionary<int, int> killCount = new Dictionary<int, int>();
    public int clearStage;

    public void SaveFromStageManager(StageManager stageManager)
    {
        //currentStage = stageManager.currentStage;
        //killCount = stageManager.killCount;
        //clearStage = stageManager.clearStage;
    }

    // ���� ����
    public List<WeaponData> weaponDataList = new List<WeaponData>();

    public void SaveFromWeaponData(List<WeaponData> weaponDataList)
    {
        this.weaponDataList = weaponDataList;
    }

    public void Initialize()  // �� �ʱ�ȭ (�׽�Ʈ��) 
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


