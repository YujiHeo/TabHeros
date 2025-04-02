﻿using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public PlayerSaveData playerData;
    public WeaponData weaponData;
    public WeaponSaveData weaponSaveData;
    public StageSaveData stageSaveData; 
    
    [SerializeField]
    private WeaponList weaponList;

    public void Start()
    {
        weaponList.GetWeapon();
    }

}
