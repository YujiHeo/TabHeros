using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.U2D.Aseprite;
using Newtonsoft.Json;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public PlayerSaveData playerData;
    public StageSaveData stageData;
    public WeaponSaveData weaponData;
    public HeroSaveData heroData;

    private static string playerSaveFilePath => Application.persistentDataPath + "/playerData.json";
    private static string stageSaveFilePath => Application.persistentDataPath + "/stageData.json";
    private static string weaponSaveFilePath => Application.persistentDataPath + "/weaponData.json";
    private static string heroSaveFilePath => Application.persistentDataPath + "/heroData.json";

    public void Start()
    {
        LoadAllData();
        Debug.Log(saveFilePath);
    }

    public void SaveAllData()
    {
        SavePlayerData();
        SaveStageData();
        SaveWeaponData();
        SaveHeroData();
    }

    public void LoadAllData()
    {
        LoadPlayerData();
        LoadStageData();
        LoadWeaponData();
        LoadHeroData();
    }

    public void SavePlayerData()
    {
        string json = JsonConvert.SerializeObject(playerData, Formatting.Indented);
        //string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(playerSaveFilePath, json);
    }

    public void LoadPlayerData()
    {
        if (File.Exists(playerSaveFilePath))
        {
            string json = File.ReadAllText(playerSaveFilePath);
            playerData = JsonConvert.DeserializeObject<PlayerSaveData>(json);
            //playerData = JsonUtility.FromJson<PlayerSaveData>(json);
        }
        else
        {
            playerData = new PlayerSaveData();
        }
    }

    public void SaveStageData()
    {
        string json = JsonConvert.SerializeObject(stageData, Formatting.Indented);
        //string json = JsonUtility.ToJson(stageData, true);
        File.WriteAllText(stageSaveFilePath, json);
    }

    public void LoadStageData()
    {
        if (File.Exists(stageSaveFilePath))
        {
            string json = File.ReadAllText(stageSaveFilePath);
            stageData = JsonConvert.DeserializeObject<StageSaveData>(json);
            //stageData = JsonUtility.FromJson<StageSaveData>(json);
        }
        else
        {
            stageData = new StageSaveData();
        }
    }

    public void SaveWeaponData()
    {
        string json = JsonConvert.SerializeObject(weaponData, Formatting.Indented);
        //string json = JsonUtility.ToJson(weaponData, true);
        File.WriteAllText(weaponSaveFilePath, json);
    }

    public void LoadWeaponData()
    {
        if (File.Exists(weaponSaveFilePath))
        {
            string json = File.ReadAllText(weaponSaveFilePath);
            weaponData = JsonConvert.DeserializeObject<WeaponSaveData>(json);
            //weaponData = JsonUtility.FromJson<WeaponSaveData>(json);
        }
        else
        {
            weaponData = new WeaponSaveData();
        }
    }

    public void SaveHeroData()
    {
        string json = JsonConvert.SerializeObject(heroData, Formatting.Indented);
        //string json = JsonUtility.ToJson(heroData, true);
        File.WriteAllText(heroSaveFilePath, json);
    }

    public void LoadHeroData()
    {
        if (File.Exists(heroSaveFilePath))
        {
            string json = File.ReadAllText(heroSaveFilePath);
            heroData = JsonUtility.FromJson<HeroSaveData>(json);
        }
        else
        {
            heroData = new HeroSaveData();
        }
    }

}
