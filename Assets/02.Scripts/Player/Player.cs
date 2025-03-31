using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]private StatManager SM;
   
   [Header("Stats")]
   public int atk;
   public double crit;
   public int critDamage;
   public int gold;
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
      atk = (int)SM.SetStatValue(PlayerStatType.Atk);
      crit = SM.SetStatValue(PlayerStatType.Crit);
      critDamage = (int)SM.SetStatValue(PlayerStatType.CritDamage);
      goldGainRate = SM.SetStatValue(PlayerStatType.GoldGain);
   }

   public void GetQuestReward(int value)
   {
      upgradePoints += value;
   }
}
