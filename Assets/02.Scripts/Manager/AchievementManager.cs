using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Achievement
{
    public string name;
    public string description;
    public int targetValue;
    public string rewardType;
    public string rewardValue; 
    public string achievementType; // JSON 매핑용 필드 추가

    [NonSerialized] public AchievementType Type;
    public int currentProgress; // 진행 현황 (저장 대상)
    public bool isCompleted;    // 달성 여부 (저장 대상)
}
[Serializable]
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

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    public void SaveAchievements()
    {
        AchievementListWrapper wrapper = new AchievementListWrapper();
        wrapper.achievements = achievements;
    
        // JsonUtility를 이용해 JSON 문자열로 변환
        string json = JsonUtility.ToJson(wrapper, true);
    
        // Application.persistentDataPath 경로에 파일을 저장
        string filePath = Path.Combine(Application.persistentDataPath, "Achievements.json");
        File.WriteAllText(filePath, json);
    }
    private void LoadAchievements()
    {
        // persistentDataPath에 저장된 파일 경로
        string filePath = Path.Combine(Application.persistentDataPath, "Achievements.json");

        string jsonText = "";

        // persistentDataPath에 파일이 존재하는 경우
        if (File.Exists(filePath))
        {
            jsonText = File.ReadAllText(filePath);
        }
        else
        {
            // Resources 폴더에서 기본 파일 읽기
            TextAsset resourceText = Resources.Load<TextAsset>("Achievements");
            if (resourceText == null)
            {
                return;
            }

            jsonText = resourceText.text;

            // 처음 로드 시 persistentDataPath로 복사하여 저장
            File.WriteAllText(filePath, jsonText);
        }

        AchievementListWrapper wrapper = JsonUtility.FromJson<AchievementListWrapper>(jsonText);
        achievements = wrapper?.achievements ?? new List<Achievement>();
        achievements.RemoveAll(a => a.isCompleted);

    }

    private void ConvertAchievementTypes()
    {
        foreach (var achievement in achievements)
            if (Enum.TryParse(achievement.achievementType, true, out AchievementType type))
                achievement.Type = type;
    }

    // 타입별 업적 조회 메서드 추가
    public List<Achievement> GetAchievementsByType(AchievementType type)
        => achievements.FindAll(a => a.Type == type);

    public void CompleteAchievement(AchievementType type)
    {
        List<Achievement> achievementsOfType = GetAchievementsByType(type);
        
        Achievement achievement = achievementsOfType.Find(a => !a.isCompleted);
        if (achievement != null &&!achievement.isCompleted)
        {
            achievement.currentProgress = achievement.targetValue;
            achievement.isCompleted = true;
            GrantReward(achievement);
            SaveAchievements();
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
            achievement.isCompleted = true;
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
                
                if (achievement.currentProgress >= achievement.targetValue)
                {
                    achievement.currentProgress = achievement.targetValue;
                    GrantReward(achievement);
                }
            }
        }
        SaveAchievements();
    }

}
