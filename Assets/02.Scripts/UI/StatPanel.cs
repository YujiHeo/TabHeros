using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerStatType
{
    Atk,
    Crit,
    CritDamage,
    GoldGain
}
public class StatPanel : MonoBehaviour
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
        { PlayerStatType.Crit, p => p.crit.ToString() },
        { PlayerStatType.CritDamage, p => p.critDamage.ToString() },
        { PlayerStatType.GoldGain, p => p.goldGainRate.ToString() }
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
    private void OnUpgradeCompleted(PlayerStatType upgradedStatType)
    {
        if (upgradedStatType == statType)
        {
            UpdateText();
        }
    }
    public void UpdateText()
    {
        int level = playerData.GetStatLevel(statType);
        
        infoText.text = $"{statNames[statType]}\n<size=52>{level}</size>";
        statText.text = statValue[statType](player);
        
        int upgradeCost = (level - 1) * 3 * 30 + 30;
        buttonText.text = $"<size=40>{upgradeCost}G</size>\n<size=48>Lv UP</size>";
    }
}
