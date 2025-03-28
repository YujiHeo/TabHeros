using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeSystem : MonoBehaviour
{
    private int target;
    [SerializeField] private Player player;
    [SerializeField] private PlayerDataBase playerData;

    public void Upgrade(PlayerStatType stat) 
    {
        int currentLevel = StatManager.instance.GetStatLevel(stat);
        int upgradeCost = (currentLevel - 1) * 3*30 + 30;
        
        if (player.gold < upgradeCost)
        {
            Debug.Log("Can't upgrade");
            return;
        }
        
        player.gold -= upgradeCost;
        StatManager.instance.UpdateStat(stat, currentLevel + 1);
        
        player.UpdatePlayerStat();
    }
    
}
