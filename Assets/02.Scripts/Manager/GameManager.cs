using UnityEngine;
using System.IO;
using Unity.PlasticSCM.Editor.WebApi;
using TMPro;
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
