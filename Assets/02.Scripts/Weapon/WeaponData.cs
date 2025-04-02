using UnityEngine;

public enum WeaponType
{
    ATKUP
}

// ���� ���� �޼��带 ����� level�� ������ ���� , level�� ���� �����Ƽ�� ���׷��̵� ����Ʈ ����

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponData : ScriptableObject
//�������� ���� �� SO�� �Ⱦ��°��� ����.
{
    [Header("Info")]
    public string name;

    public Sprite Icon;

    public int level;  // ���ϴ� �༮���� �����;� �� 
    public int ability;

    public int ownUpgradePoint;
    public int id;
}