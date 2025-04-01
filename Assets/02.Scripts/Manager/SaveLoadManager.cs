using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.U2D.Aseprite;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public PlayerSaveData playerData;
    public StageSaveData stageData;
    public WeaponSaveData weaponData;
    public HeroSaveData heroData;

    private static string saveFilePath => Application.persistentDataPath + "/saveData.json";

    public void Start()
    {
        LoadAllData();
        Debug.Log(saveFilePath);
    }

    public void SaveAllData()
    {
        SaveDataGeneric(ref playerData, data => data.playerSaveData = playerData);
        SaveDataGeneric(ref stageData, data => data.stageSaveData = stageData);
        SaveDataGeneric(ref weaponData, data => data.weaponSaveData = weaponData);
        //SaveDataGeneric(ref heroData, data => data.heroSaveData = heroData);
    }

    public void LoadAllData()
    {
        LoadDataGeneric(ref playerData, data => data.playerSaveData);
        LoadDataGeneric(ref stageData, data => data.stageSaveData);
        LoadDataGeneric(ref weaponData, data => data.weaponSaveData);
        //LoadDataGeneric(ref heroData, data => data.heroSaveData = heroData);
    }

    public void SaveGame(SaveData saveData) 
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

    private void SaveDataGeneric<T>(ref T data, System.Action<SaveData> setSaveData)
    {
        SaveData saveData = LoadGame();
        setSaveData(saveData);
        SaveGame(saveData);
    }

    private void LoadDataGeneric<T>(ref T data, System.Func<SaveData, T> getSaveData) where T : new()
    {
        data = getSaveData(LoadGame());
        if (data == null)
        {
            data = new T();
        }
    }

}
