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
    [SerializeField] private PlayerGoods playerGoods;

    private void Update()
    {
        playerGoods.updateText();
    }

    public void Upgrade(PlayerStatType stat) 
    {
        int currentLevel = StatManager.instance.GetStatLevel(stat);
        int upgradeCost = GetUpgradeCost(currentLevel);
        
        if (player.gold < upgradeCost)
        {
            Debug.Log("Can't upgrade");
            return;
        }
        
        player.gold -= upgradeCost;
        StatManager.instance.UpdateStat(stat, currentLevel + 1);
        
        playerGoods.updateText();
        player.UpdatePlayerStat();
    }
    public int GetUpgradeCost(int level)
    {
        return (level - 1) * 3 * 30 + 30;
    }
}
