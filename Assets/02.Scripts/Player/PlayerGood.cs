using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGoods : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] Player player;
    
    private void Start()
    {
        updateText();
    }

    public void updateText()
    {
        goldText.text = $"{player.gold} G";
        pointText.text = player.upgradePoints.ToString();
    }
}
