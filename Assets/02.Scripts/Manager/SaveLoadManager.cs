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

    protected override void Awake()
    {
        base.Awake();
        LoadAllData();
    }

    public void InitializeNewGame()
    {
        playerData = new PlayerSaveData();
        stageData = new StageSaveData();
        weaponData = new WeaponSaveData();
        heroData = new HeroSaveData();

        SaveAllData();
    }

    public void SaveAllData()
    {
        HeroManager.instance.SaveHeroData();
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
        File.WriteAllText(playerSaveFilePath, json);
    }

    public void LoadPlayerData()
    {
        if (File.Exists(playerSaveFilePath))
        {
            string json = File.ReadAllText(playerSaveFilePath);
            playerData = JsonConvert.DeserializeObject<PlayerSaveData>(json);
        }
        else
        {
            playerData = new PlayerSaveData();
        }
    }

    public void SaveStageData()
    {
        string json = JsonConvert.SerializeObject(stageData, Formatting.Indented);
        File.WriteAllText(stageSaveFilePath, json);
    }

    public void LoadStageData()
    {
        if (File.Exists(stageSaveFilePath))
        {
            string json = File.ReadAllText(stageSaveFilePath);
            stageData = JsonConvert.DeserializeObject<StageSaveData>(json);
        }
        else
        {
            stageData = new StageSaveData();
        }
    }

    public void SaveWeaponData()
    {
        weaponData = UIInventory.instance.GetWeaponSaveData();
        string json = JsonConvert.SerializeObject(weaponData, Formatting.Indented);
        File.WriteAllText(weaponSaveFilePath, json);
    }

    public void LoadWeaponData()
    {
        if (File.Exists(weaponSaveFilePath))
        {
            string json = File.ReadAllText(weaponSaveFilePath);
            weaponData = JsonConvert.DeserializeObject<WeaponSaveData>(json);
        }
    }

    public void SaveHeroData()
    {
        heroData = HeroManager.instance.GetHeroSaveData(); 
        string json = JsonConvert.SerializeObject(heroData, Formatting.Indented);
        File.WriteAllText(heroSaveFilePath, json);
    }


    public void LoadHeroData()
    {
        if (File.Exists(heroSaveFilePath))
        {
            string json = File.ReadAllText(heroSaveFilePath);
            heroData = JsonConvert.DeserializeObject<HeroSaveData>(json);
        }
        else
        {
            heroData = new HeroSaveData();
        }
    }
}
