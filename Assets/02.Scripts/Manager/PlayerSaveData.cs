using System;
using System.Collections.Generic;

public class SaveData // ������ ���̺� ����. �ʱ�ȭ ��� ���
{
    public PlayerSaveData playerCoreData = new PlayerSaveData();
    public StatCoreData statCoreData = new StatCoreData();
    public WeaponData weaponCoreData = new WeaponData();
    // public HeroCoreData heroCoreData ����� �ڵ� ���� ���̺� ���
    //public TrophyCoreData trophyCoreData ���� ���̺� ���

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

//public int currentStage;   // ���� ��������
//public List<int> completedStages = new List<int>();  // �Ϸ�� �������� ����Ʈ

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
public class StatCoreData  // ���� ���� ���嵥����
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
    public int weaponLevel;                // ���� ����
    public int weaponAbility;              // ���� �ɷ�ġ
    public int weaponUpgradePoints;        // ���� ���׷��̵� ����Ʈ
    // public List<WeaponList> weaponlist; // ���� ����Ʈ�� ����

}

// public class TrophyCoreData

