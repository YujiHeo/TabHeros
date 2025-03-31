using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum AchievementType
{
    Click,
    Gold,
    Hero,
    Weapon,
    Stage
}
public class AchievementPanel : MonoBehaviour
{
    [SerializeField] private AchievementType achievementType;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI achieveText;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI rewardText;
    [SerializeField] private Button button;
    [SerializeField] private Image progressBar;
    
    private Dictionary<AchievementType, string> achievementLabels = new Dictionary<AchievementType, string>()
    {
        { AchievementType.Click, "Click" },
        { AchievementType.Gold, "Gold" },
        { AchievementType.Hero, "Hero" },
        { AchievementType.Stage, "Stage" },
        { AchievementType.Weapon, "Weapon" }
    };
    
    private void Start()
    {
        UpdateUI();
    }
    public void Initialize(int achievementIndex)
    {
        this.achievementIndex = achievementIndex; // 인덱스 저장
        UpdateUI();
    }

    private int achievementIndex;

    public void UpdateUI()
    {
        List<Achievement> achievementsOfType = AchievementManager.instance.GetAchievementsByType(achievementType);

        // 유효성 체크 강화
        if (achievementsOfType == null || achievementsOfType.Count <= achievementIndex)
        {
            gameObject.SetActive(false);
            return;
        }

        Achievement achievement = achievementsOfType[achievementIndex]; // 저장된 인덱스 사용

        // UI 업데이트
        achieveText.text = achievement.name;
        progressText.text = $"{achievement.currentProgress}/{achievement.targetValue}";
        rewardText.text = $"{achievement.rewardValue}";
        progressBar.fillAmount = Mathf.Clamp01((float)achievement.currentProgress / achievement.targetValue);
    }

    private void ButtonClicked()
    {
        
    }
}
