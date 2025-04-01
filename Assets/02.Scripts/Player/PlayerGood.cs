using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGoods : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI pointText;
    private PlayerSaveData playerData;
    
    private void Start()
    {
        playerData = SaveLoadManager.instance.playerData;
        updateText();
    }

    public void updateText()
    {
        goldText.text = $"{playerData.gold}G";
        pointText.text = playerData.upgradePoints.ToString();
    }
}
