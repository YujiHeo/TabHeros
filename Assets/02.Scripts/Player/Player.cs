using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]private PlayerDataBase playerData;
   
   [Header("Stats")]
   public int atk;
   public double crit;
   public int critDamage;
   public int gold;
   public int upgradePoints;
   public double goldGainRate;

   private void Start()
   {
      InitPlayerData();
   }

   private void InitPlayerData()
   {
      int atkLevel = playerData.GetStatLevel(PlayerStatType.Atk);
      int critLevel = playerData.GetStatLevel(PlayerStatType.Crit);
      int critDamageLevel = playerData.GetStatLevel(PlayerStatType.CritDamage);
      int goldGainLevel = playerData.GetStatLevel(PlayerStatType.GoldGain);
 
      atk = (atkLevel - 1) * 10 + 10;  
      crit = (critLevel - 1) * 0.1f + 5;
      critDamage = (critDamageLevel - 1) * 10 + 100;
      goldGainRate = (goldGainLevel - 1) * 10 + 100;
   }
}
