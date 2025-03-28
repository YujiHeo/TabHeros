using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]private PlayerDataBase playerData;
   [SerializeField]private StatManager SM;
   
   [Header("Stats")]
   public int atk;
   public double crit;
   public int critDamage;
   public int gold = 3000;
   public int upgradePoints;
   public double goldGainRate;

   private void Start()
   {
      UpdatePlayerStat();
      SM = StatManager.instance;
   }

   public void UpdatePlayerStat()
   {
      UpdatePlayerData();
   }
   private void UpdatePlayerData()
   { 
      atk = (int)SM.GetStatValue(PlayerStatType.Atk);
      crit = SM.GetStatValue(PlayerStatType.Crit);
      critDamage = (int)SM.GetStatValue(PlayerStatType.CritDamage);
      goldGainRate = SM.GetStatValue(PlayerStatType.GoldGain);
   }
}
