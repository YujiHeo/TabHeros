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
    [SerializeField] private GameObject goldLackPanel;
    [SerializeField] private TMP_Text timeLimit;

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

    public void ShowGoldLackWarning()
    {
        StartCoroutine(GoldLackCountdown());
    }

    private IEnumerator GoldLackCountdown()
    {
        goldLackPanel.SetActive(true);

        int time = 5;
        while (time > 0)
        {
            timeLimit.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }

        goldLackPanel.SetActive(false);
    }

}


