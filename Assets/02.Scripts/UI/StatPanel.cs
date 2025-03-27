using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum PlayerStatType
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
    [Header("UI")]
    [SerializeField]private TextMeshProUGUI buttonText;
    [SerializeField]private TextMeshProUGUI infoText;
    [SerializeField]private TextMeshProUGUI statText;
    
    
    private void Start()
    {
        UpdateText();
    }
    
    private void UpdateText()
    {
        
        switch (statType)
        {
            case PlayerStatType.Atk : 
                infoText.text = $"공격력\n<size=52>{playerData.atkLevel}</size>"; 
                statText.text = player.atk.ToString();
                buttonText.text = $"<size=40>{((playerData.atkLevel-1)*3)*30+30}G</size>\n<size=48>Lv UP</size>"; break;
            
            case PlayerStatType.Crit : 
                infoText.text = $"크리티컬 확률\n<size=52>{playerData.critLevel}</size>"; 
                statText.text = player.crit.ToString();
                buttonText.text = $"<size=40>{((playerData.critLevel-1)*3)*30+30}G</size>\n<size=48>Lv UP</size>"; break;
            
            case PlayerStatType.CritDamage : 
                infoText.text = $"크리티컬 데미지\n<size=52>{playerData.critDamageLevel}</size>"; 
                statText.text = player.critDamage.ToString();
                buttonText.text = $"<size=40>{((playerData.critDamageLevel-1)*3)*30+30}G</size>\n<size=48>Lv UP</size>"; break;
            
            case PlayerStatType.GoldGain : 
                infoText.text = $"골드 획득량\n<size=52>{playerData.gainGoldLevel}</size>"; 
                statText.text = player.critDamage.ToString();
                buttonText.text = $"<size=40>{((playerData.gainGoldLevel-1)*3)*30+30}G</size>\n<size=48>Lv UP</size>"; break;
        }
    }
}
