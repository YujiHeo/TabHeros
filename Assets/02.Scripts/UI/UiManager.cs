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
    public void UpdateCurrencyTxt() // ��ȭ ���� ui ������Ʈ (���� ���)
    {

    }

}


