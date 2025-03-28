using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance { get; private set; }

    public PlayerCoreData playerData;
    public StatCoreData statData;
    public WeaponData weaponData;

    private static string saveFilePath => Application.persistentDataPath + "/saveData.json";

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
        LoadAllData();

    }

    public void SaveAllData()
    {
        SavePlayerData();
        SaveStatData();
        SaveWeaponData();
    }

    public void LoadAllData()
    {
        LoadPlayerData();
        LoadStatData();
        LoadWeaponData();
    }

    public void SaveGame(SaveData saveData)  // 기본 저장 기능
    {
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(saveFilePath, json);
    }

    public SaveData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            return new SaveData();
        }
    }



    public void SaveStatData()
    {
        SaveData saveData = LoadGame();
        saveData.statCoreData = statData;
        SaveGame(saveData);
    }

    public void LoadStatData()
    {
        StatCoreData data = LoadGame().statCoreData;
        if (data == null)
        {
            data = new StatCoreData();
        }
        statData = data;
    }



    public void SavePlayerData()
    {
        SaveData saveData = LoadGame();
        saveData.playerCoreData = playerData;
        SaveGame(saveData);
    }
    public void LoadPlayerData()
    {
        PlayerCoreData data = LoadGame().playerCoreData;
        if (data == null)
        {
            data = new PlayerCoreData();
        }
        playerData = data;
    }




    public void SaveWeaponData()
    {
        SaveData saveData = LoadGame();
        saveData.weaponCoreData = weaponData;
        SaveGame(saveData);
    }

    public void LoadWeaponData()
    {
        WeaponData data = LoadGame().weaponCoreData;
        if (data == null)
        {
            data = new WeaponData();
        }
        weaponData = data;
    }

}
