using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : Singleton<SaveLoadManager>
{

    public PlayerCoreData playerData;
    public StatCoreData statData;
    public WeaponData weaponData;
    public WeaponList weaponList;

    private static string saveFilePath => Application.persistentDataPath + "/saveData.json";

    public void Awake()
    {

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
        for (int i = 0; i < weaponList.weaponList.Count; i++)
        {

            WeaponData cloneWeapon = Instantiate(weaponList.weaponList[i]);

        }
    }

}
