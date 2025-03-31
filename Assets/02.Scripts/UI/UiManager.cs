using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void UpdateCurrencyTxt() // 재화 관련 ui 업데이트 (공통 기능)
    {

    }

}


