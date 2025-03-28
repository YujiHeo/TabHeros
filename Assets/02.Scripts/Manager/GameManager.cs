using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // 싱글톤 사용

    public PlayerCoreData playerData;
    public StatCoreData statData;
    public WeaponData weaponData;

    private static string saveFilePath => Application.persistentDataPath + "/saveData.json";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    // 하나를 묶어줄 수 있는 메서드 (중복을 줄일 수 있는)

    public void AttackUpgrade(int atkChangeNum)
    {

        //PlayerUpgrade(계산완료된수치값);

        SaveLoadManager.Instance.statData.atk = atkChangeNum;
        SaveLoadManager.Instance.SaveStatData();

    }


}
