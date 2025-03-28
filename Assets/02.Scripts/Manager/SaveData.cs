using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    // �⺻���� ���� ���� ��Ȳ
    public int currentStage;                // ���� ��������
    public float currentCurrency;           // ������ ��ȭ (��� ��)
    public List<int> completedStages = new List<int>();  // �Ϸ�� �������� ����Ʈ

    // ��ȭ ������
    public int gold;
    public int upgradePoints;
    public double goldGainRate;

    // ���� ���� ����
    public int atkLevel;
    public int critLevel;
    public int critDamageLevel;
    public int gainGoldLevel;
    public int atk;
    public double crit;
    public int critDamage;

    
    // ���׷��̵� �� ��� ����
    public int weaponLevel;                // ���� ����
    public int weaponAbility;              // ���� �ɷ�ġ
    public int weaponUpgradePoints;        // ���� ���׷��̵� ����Ʈ
    public List<string> equippedItems = new List<string>();  // ������ ��� ����Ʈ

    // ���� ����
    public List<string> achievementProgress; // ���� ���� (���� ����)

}

[Serializable]
public class Upgrade
{
    public string upgradeName;   // ���׷��̵� �̸�
    public int level;            // ���׷��̵� ����
}
