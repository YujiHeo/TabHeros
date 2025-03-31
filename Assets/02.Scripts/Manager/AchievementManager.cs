using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
[System.Serializable]
public class Achievement
{
    public string name;
    public string description;
    public int targetValue;
    public string rewardType;
    public string rewardValue; 
    public string achievementType; // JSON 매핑용 필드 추가

    [NonSerialized]public AchievementType Type;
    [NonSerialized] public int currentProgress; // 진행 현황 (저장 대상)
    [NonSerialized] public bool isCompleted;    // 달성 여부 (저장 대상)
}
[System.Serializable]
public class AchievementListWrapper
{   
    public List<Achievement> achievements;
}

public class AchievementManager : Singleton<AchievementManager>
{
    public List<Achievement> achievements = new List<Achievement>();
    private void Awake()
    {
        LoadAchievements();
        ConvertAchievementTypes();
    }

    private void LoadAchievements()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Achievements");
        if (jsonText == null)
        {
            Debug.LogError("Achievements.json 파일을 찾을 수 없음");
            return;
        }

        try
        {
            AchievementListWrapper wrapper = JsonUtility.FromJson<AchievementListWrapper>(jsonText.text);
            achievements = wrapper?.achievements ?? new List<Achievement>();
        }
        catch (Exception ex)
        {
            Debug.LogError($"JSON 로드 실패: {ex.Message}");
        }
    }
    private void ConvertAchievementTypes()
    {
        foreach (var achievement in achievements)
            if (Enum.TryParse(achievement.achievementType, true, out AchievementType type))
                achievement.Type = type;
            else
                Debug.LogError($"잘못된 업적 타입: {achievement.achievementType}");
    }

    // 타입별 업적 조회 메서드 추가
    public List<Achievement> GetAchievementsByType(AchievementType type)
        => achievements.FindAll(a => a.Type == type);
}
