  using System;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

public enum PlayerStatType
{
    Atk,
    Crit,
    CritDamage,
    GoldGain
}
public class StatPanel  : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]private PlayerStatType statType;
    [SerializeField]private PlayerDataBase playerData;
    [SerializeField]private Player player;
    [SerializeField]private UpgradeSystem upgradeSystem;
    public PlayerSaveData saveData;
    [Header("UI")]
    [SerializeField]private TextMeshProUGUI buttonText;
    [SerializeField]private TextMeshProUGUI infoText;
    [SerializeField]private TextMeshProUGUI statText;
    [SerializeField]private Button upgradeButton;

    private Coroutine upgradeCoroutine;
    private bool isPointerDown;
    
    

    public void OnUpgradeButtonClicked()
    {
        upgradeSystem.Upgrade(statType);
        saveData.SaveFromPlayer(player);
        
        UpdateText();
    }

    private void OnEnable()
    {
        StatManager.OnStatUpdated += UpdateText;
    }
    
    private void Start()
    {
        UpdateText();
        saveData.SaveFromPlayer(player);

    }

    private void OnDisable()
    {
        StatManager.OnStatUpdated -= UpdateText;
    }

    public void UpdateText()
    {
        Color activeColor;
        Color inactiveColor;
        ColorUtility.TryParseHtmlString("#F3883D", out activeColor); 
        ColorUtility.TryParseHtmlString("#989390", out inactiveColor);
        
        int level = StatManager.instance.GetStatLevel(statType);
        float stat = StatManager.instance.SetStatValue(statType);
        
        infoText.text = $"Lv. {level}";
        if(statType == PlayerStatType.Atk) statText.text = $"{stat}";
        else statText.text = $"{stat}%";
        
        int upgradeCost = upgradeSystem.GetUpgradeCost(level);
        buttonText.text = $"{upgradeCost} G";
        
        upgradeButton.image.color = player.gold >= upgradeCost ? activeColor : inactiveColor;
    }
    
    public void OnPointerDown()
    {
        isPointerDown = true;
        if (upgradeCoroutine == null)
        {
            upgradeCoroutine = StartCoroutine(UpgradeRoutine());
        }
    }

    public void OnPointerUp()
    {
        isPointerDown = false;
        if (upgradeCoroutine != null)
        {
            StopCoroutine(upgradeCoroutine);
            upgradeCoroutine = null;
        }
    }
    private IEnumerator UpgradeRoutine()
    {
        yield return new WaitForSecondsRealtime(0.2f); // 초기 0.2초 대기

        while (isPointerDown)   
        {
            int level = StatManager.instance.GetStatLevel(statType);
            int upgradeCost = upgradeSystem.GetUpgradeCost(level);

            if (player.gold < upgradeCost)
                break;

            upgradeSystem.Upgrade(statType);
            UpdateText();
            yield return new WaitForSecondsRealtime(0.2f); // 연속 업그레이드 간격
        }
    }
    
}
