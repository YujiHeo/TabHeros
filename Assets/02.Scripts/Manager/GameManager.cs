using UnityEngine;
using System.IO;
using Unity.PlasticSCM.Editor.WebApi;
using TMPro;
using System.Collections.Generic;

//public enum CurrencyType
//{
//    Gold,
//    UpgradePoints
//}

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public PlayerSaveData playerData;
    public WeaponData weaponData;

    [SerializeField]
    private WeaponList weaponList;

    //private Dictionary<CurrencyType, System.Action<int>> currentyActions;

    //private void Start()
    //{
    //    UiManager.instance.UpdateCurrencyTxt(player.gold, player.upgradePoints);

    //    currencyActions = new Dictionary<CurrencyType, System.Action<int>>
    //    { CurrencyType.Gold, amount => UpdateCurrency(CurrencyType.Gold, amount) }
    //    { CurrencyType.Gold, amount => UpdateCurrency(CurrencyType.Gold, amount) }
    //}

    //public void AddCurrency(CurrencyType currencyType, int amount)  // 재화 추가하는 메서드
    //{
    //    switch (currencyType)
    //    {
    //        case CurrencyType.Gold:
    //            player.gold += amount;
    //            UiManager.instance.UpdateCurrencyTxt(player.gold, player.upgradePoints);
    //            break;
    //        case CurrencyType.UpgradePoints:
    //            playerData.upgradePoints += amount;
    //            UiManager.instance.UpdateCurrencyTxt(player.gold, player.upgradePoints);
    //            break;
    //    }
    //}

    //public void SpendCurrency(int amount)  // 재화 소비하는 메서드
    //{
    //    switch (currencyType)
    //    {
    //        case CurrencyType.Gold:
    //            if (player.gold >= amount)
    //            {
    //                player.gold -= amount;
    //                UiManager.instance.UpdateCurrencyTxt(player.gold, player.upgradePoints);
    //            }
    //            else
    //            {
    //                UiManager.instance.ShowWarningMessage("Not enough gold!");
    //            }
    //            break;
    //        case CurrencyType.UpgradePoints:
    //            if (player.upgradePoints >= amount)
    //            {
    //                player.upgradePoints -= amount;
    //                UiManager.instance.UpdateCurrencyTxt(player.gold, player.upgradePoints);
    //            }
    //            else
    //            {
    //                UiManager.instance.ShowWarningMessage("Not enough upgrade points!");
    //            }
    //            break;
    //    }
    //}


    //// 아래는 아직 진행 중... 

    //public void AttackUpgrade(int atkChangeNum)
    //{

    //    PlayerUpgrade(계산완료된수치값);

    //    SaveLoadManager.instance.statData.atk = atkChangeNum;
    //    SaveLoadManager.instance.SaveStatData();

    //}

    public void Start()
    {
        weaponList.GetWeapon();
    }

}
