using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class UiManager : Singleton<UiManager>
{
    [SerializeField] private TMP_Text warningTxt;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void UpdateCurrencyTxt(TMP_Text currencyText, int amount)
    {
        if (currencyText != null)
        {
            currencyText.text = $"Currency: {amount}";
        }
    }

    public void ShowWarningMessage(string message)
    {
        StartCoroutine(ShowWarningMessageCoroutine(message));
    }

    private IEnumerator ShowWarningMessageCoroutine(string message)
    {
        warningTxt.text = message;
        warningTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); // 2초 후 경고 메시지 비활성화
        warningTxt.gameObject.SetActive(false);
    }

}


