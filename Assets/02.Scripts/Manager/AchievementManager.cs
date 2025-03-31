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

    [NonSerialized] public AchievementType Type;
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
    [SerializeField] private Player player;
    private int achievementIndex;

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

    public void CompleteAchievement(AchievementType type)
    {
        List<Achievement> achievementsOfType = GetAchievementsByType(type);
        
        Achievement achievement = achievementsOfType.Find(a => !a.isCompleted);
        if (!achievement.isCompleted)
        {
            achievement.currentProgress = achievement.targetValue;
            achievement.isCompleted = true;
            GrantReward(achievement);
            Debug.Log($"업적 완료: {achievement.name}");
        }
    }
    private void GrantReward(Achievement achievement)
    {
        if(achievement.rewardType == "upgradePoints")
            player.GetQuestReward(int.Parse(achievement.rewardValue));
    }

    public bool ReachTargetValue(AchievementType achievementType)
    {
        List<Achievement> achievementsOfType = GetAchievementsByType(achievementType);

        // 유효성 체크
        if (achievementsOfType == null || achievementsOfType.Count <= achievementIndex)
        {
            return false;
        }

        Achievement achievement = achievementsOfType[achievementIndex];

        // 업적이 이미 완료되었는지 확인
        if (achievement.isCompleted)
        {
            return false;
        }

        // 진행 상태 확인 후 목표 달성 여부 체크
        if (achievement.currentProgress >= achievement.targetValue)
        {
            CompleteAchievement(achievementType);
            return true;
        }
        return false;
    }
    public void IncreaseAchievementProgress(AchievementType type, int amount)
    {
        // 해당 타입의 업적 목록 가져오기
        List<Achievement> achievementsOfType = GetAchievementsByType(type);
        if (achievementsOfType == null || achievementsOfType.Count == 0)
            return;
    
        // 모든 업적에 대해 진행도 업데이트
        foreach (Achievement achievement in achievementsOfType)
        {
            if (!achievement.isCompleted)
            {
                achievement.currentProgress += amount;
                // 목표치 초과하지 않도록 클램프 처리
                if (achievement.currentProgress >= achievement.targetValue)
                {
                    achievement.currentProgress = achievement.targetValue;
                    achievement.isCompleted = true;
                    GrantReward(achievement);
                }
            }
        }
    }

}
