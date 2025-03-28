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
      atk = (playerData.atkLevel-1) * 10 + 10;
      crit = (playerData.critLevel-1) * 0.1 + 5;
      critDamage = (playerData.critDamageLevel-1) * 10 + 100;
      goldGainRate = (playerData.gainGoldLevel-1) * 10 + 100;
   }
   
}
