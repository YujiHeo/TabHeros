using System;
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
    private int achievementIndex;
    [SerializeField] private PlayerGoods playerGoods;
    [SerializeField] private AchievementType achievementType;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI achieveText;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI rewardText;
    [SerializeField] private Button button;
    [SerializeField] private Image progressBar;
    
    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
        playerGoods.updateText();
    }


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
        achieveText.text = achievement.description;
        progressText.text = $"{achievement.currentProgress}/{achievement.targetValue}";
        rewardText.text = $"{achievement.rewardValue}";
        progressBar.fillAmount = Mathf.Clamp01((float)achievement.currentProgress / achievement.targetValue);
    }

    public void ButtonClicked()
    {
        bool isCleared = AchievementManager.instance.ReachTargetValue(achievementType);
        if (isCleared)
        {
            Destroy(this.gameObject);
            playerGoods.updateText();
        }
    }   
}
