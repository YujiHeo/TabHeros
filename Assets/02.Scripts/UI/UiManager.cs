using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
    [SerializeField] private TextMeshProUGUI GoldTxt;

    private void Update()
    {
        if (GoldTxt != null)
        {
            GoldTxt.text = $"<sprite=0>{SaveLoadManager.instance.playerData.gold} G";
        }
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenErrorPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

}


