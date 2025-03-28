using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{

    private int target;
    [SerializeField]private PlayerDataBase playerData;
    public void Upgrade(PlayerStatType stat)
    {
        
        switch (stat)
        {
            case PlayerStatType.Atk:
            target = playerData.atkLevel;
            break;
            case PlayerStatType.Crit:
            target = playerData.critLevel;
            break;
            case PlayerStatType.CritDamage:
            target = playerData.critDamageLevel;
            break;
            case PlayerStatType.GoldGain:
            target = playerData.gainGoldLevel;
            break;
        }
        
    }
    
}
