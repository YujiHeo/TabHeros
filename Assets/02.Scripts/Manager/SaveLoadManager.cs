using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public PlayerSaveData playerData;

    private static string saveFilePath => Application.persistentDataPath + "/saveData.json";

    public void Start()
    {
        playerData = LoadGame();
    }

    public void SaveGame(PlayerSaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
    }

    public PlayerSaveData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<PlayerSaveData>(json);
        }
        else
        {
            return new PlayerSaveData();
        }
    }

    public void InitializeData()  // 테스트용 초기화
    {
        playerData = new PlayerSaveData();
        playerData.Initialize();
        SaveGame(playerData);
    }

}
