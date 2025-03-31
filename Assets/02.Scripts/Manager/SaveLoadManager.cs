using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public PlayerSaveData playerData;
    public StatCoreData statData;
    public WeaponData weaponData;

    private static string saveFilePath => Application.persistentDataPath + "/saveData.json";

    public void Start()
    {
        LoadAllData();
    }

    public void SaveAllData()
    {
        SaveData saveData = LoadGame();
        SaveDataGeneric(ref saveData, playerData);
        SaveDataGeneric(ref saveData, statData);
        SaveDataGeneric(ref saveData, weaponData);
        SaveGame(saveData);
    }

    public void LoadAllData()
    {
        SaveData saveData = LoadGame();
        playerData = LoadDataGeneric(saveData, playerData);
        statData = LoadDataGeneric(saveData, statData);
        weaponData = LoadDataGeneric(saveData, weaponData);
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

    private void SaveDataGeneric<T>(ref SaveData saveData, T data) where T : class
    {
        saveData.SetData(data);
    }

    private T LoadDataGeneric<T>(SaveData saveData, T data) where T : class, new()
    {
        return saveData.GetData(ref data);
    }

}
