using UnityEngine;
using System.IO;

public class GameManager : Singleton<GameManager>
{
    //public static GameManager instance;  // 싱글톤 사용

    public PlayerCoreData playerData;
    public StatCoreData statData;
    //public WeaponData weaponData;

    [SerializeField]
    private WeaponList weaponList;

    public static Player player { get; private set; }

    private static string saveFilePath => Application.persistentDataPath + "/saveData.json";

    // 하나를 묶어줄 수 있는 메서드 (중복을 줄일 수 있는)

    public void AttackUpgrade(int atkChangeNum)
    {

        //PlayerUpgrade(계산완료된수치값);

        SaveLoadManager.instance.statData.atk = atkChangeNum;
        SaveLoadManager.instance.SaveStatData();
    }

    public void Start()
    {
        //SaveLoadManager.instance.LoadWeaponData();

        weaponList.GetWeapon();
    }
}
