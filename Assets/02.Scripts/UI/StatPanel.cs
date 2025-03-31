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
    
    [Header("UI")]
    [SerializeField]private TextMeshProUGUI buttonText;
    [SerializeField]private TextMeshProUGUI infoText;
    [SerializeField]private TextMeshProUGUI statText;
    [SerializeField]private Button upgradeButton;

    private Coroutine upgradeCoroutine;
    private bool isPointerDown;

    private Dictionary<PlayerStatType, string> statNames = new Dictionary<PlayerStatType, string>()
    {
        { PlayerStatType.Atk, "공격력" },
        { PlayerStatType.Crit, "크리티컬 확률" },
        { PlayerStatType.CritDamage, "크리티컬 데미지" },
        { PlayerStatType.GoldGain, "골드 획득량" }
    };
    
    private Dictionary<PlayerStatType, Func<Player, string>> statValue = new Dictionary<PlayerStatType, Func<Player, string>>()
    {
        { PlayerStatType.Atk, p => p.atk.ToString() },
        { PlayerStatType.Crit, p => $"{p.crit.ToString("N1")}" +"%"},
        { PlayerStatType.CritDamage, p => $"{p.critDamage.ToString()}"+"%" },
        { PlayerStatType.GoldGain, p => $"{p.goldGainRate.ToString()}"+"%" }
    };

    public void OnUpgradeButtonClicked()
    {
        upgradeSystem.Upgrade(statType);
        UpdateText();
    }

    private void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        Color activeColor;
        Color inactiveColor;
        ColorUtility.TryParseHtmlString("#F3883D", out activeColor); 
        ColorUtility.TryParseHtmlString("#989390", out inactiveColor);
        
        int level = StatManager.instance.GetStatLevel(statType);
        
        infoText.text = $"{statNames[statType]}\n<size=40>Lv. {level}</size>";
        statText.text = statValue[statType](player);
        
        int upgradeCost = upgradeSystem.GetUpgradeCost(level);
        buttonText.text = $"<size=40>{upgradeCost}G</size>\n<size=48>Lv UP</size>";
        
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
