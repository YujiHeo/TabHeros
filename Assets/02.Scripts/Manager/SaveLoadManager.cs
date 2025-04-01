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

    private static string playerSaveFilePath => Application.persistentDataPath + "/playerData.json";
    private static string stageSaveFilePath => Application.persistentDataPath + "/stageData.json";
    private static string weaponSaveFilePath => Application.persistentDataPath + "/weaponData.json";
    private static string heroSaveFilePath => Application.persistentDataPath + "/heroData.json";

    public void Start()
    {
        LoadAllData();
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
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(playerSaveFilePath, json);
    }

    public void LoadPlayerData()
    {
        if (File.Exists(playerSaveFilePath))
        {
            string json = File.ReadAllText(playerSaveFilePath);
            playerData = JsonUtility.FromJson<PlayerSaveData>(json);
        }
        else
        {
            playerData = new PlayerSaveData();
        }
    }

    public void SaveStageData()
    {
        string json = JsonUtility.ToJson(stageData, true);
        File.WriteAllText(stageSaveFilePath, json);
    }

    public void LoadStageData()
    {
        if (File.Exists(stageSaveFilePath))
        {
            string json = File.ReadAllText(stageSaveFilePath);
            stageData = JsonUtility.FromJson<StageSaveData>(json);
        }
        else
        {
            stageData = new StageSaveData();
        }
    }

    public void SaveWeaponData()
    {
        string json = JsonUtility.ToJson(weaponData, true);
        File.WriteAllText(weaponSaveFilePath, json);
    }

    public void LoadWeaponData()
    {
        if (File.Exists(weaponSaveFilePath))
        {
            string json = File.ReadAllText(weaponSaveFilePath);
            weaponData = JsonUtility.FromJson<WeaponSaveData>(json);
        }
        else
        {
            weaponData = new WeaponSaveData();
        }
    }

    public void SaveHeroData()
    {
        string json = JsonUtility.ToJson(heroData, true);
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
