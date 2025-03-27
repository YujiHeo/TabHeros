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
   public double gainGoldRate;

   private void Start()
   {
      InitPlayerData();
   }

   private void InitPlayerData()
   {
      atk += playerData.atkLevel * 10;
      crit += playerData.critLevel * 0.1;
      critDamage += playerData.critDamageLevel * 10;
   }
   
   
   public void UpgradePlayerAtk()
   {
      playerData.atkLevel++;
      //Update UIText();
   }
   
   public void UpgradePlayerCrit()
   {
      playerData.critLevel++;
      //Update UIText();
   } 
   
   public void UpgradePlayerCritDamage()
   {
      playerData.critDamageLevel++;
      //Update UIText();
   }

   public void UpgradePlayerGoldRate()
   {
      gainGoldRate += 0.15;
      //Update UI Text();
   }
   
}
