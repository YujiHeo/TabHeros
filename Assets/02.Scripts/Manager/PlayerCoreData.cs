using System;
using System.Collections.Generic;

// Singleton<T> �����ϰڽ��ϴ�.

public class SaveData // ������ ���̺� ����. �ʱ�ȭ ��� ���
{
    public PlayerCoreData playerCoreData = new PlayerCoreData();
    public StatCoreData statCoreData = new StatCoreData();
    public WeaponData weaponCoreData = new WeaponData();
   // public HeroCoreData heroCoreData ����� �ڵ� ���� ���̺� ���
    //public TrophyCoreData trophyCoreData ���� ���̺� ���
}

[Serializable]
public class PlayerCoreData
{
    // �⺻���� ���� ���� ��Ȳ
    public int currentStage;                // ���� ��������
    public List<int> completedStages = new List<int>();  // �Ϸ�� �������� ����Ʈ

    // ��ȭ ������
    public int gold; // ���� ��� ������
    public double goldGainRate;  // ��� ȹ�淮
    public int upgradePoints;  // ��� ���׷��̵��� �� ���� ����Ʈ
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

