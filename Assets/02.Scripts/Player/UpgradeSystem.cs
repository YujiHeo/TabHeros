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
    public UnityEvent<PlayerStatType> onUpgradeButtonClick;
    
    public void UpgradeStat(PlayerStatType stat)
    {
        Debug.Log(stat);
        Upgrade(stat);
        onUpgradeButtonClick?.Invoke(stat);
    }

    private void Upgrade(PlayerStatType stat)
    {
        int currentLevel = playerData.GetStatLevel(stat);
        int upgradeCost = (currentLevel - 1) * 3 + 30;
        
        if (player.gold < upgradeCost)
        {
            Debug.Log("Can't upgrade");
            return;
        }
        
        player.gold -= upgradeCost;
        playerData.UpdateStat(stat, currentLevel + 1);
        
    }
    
}
