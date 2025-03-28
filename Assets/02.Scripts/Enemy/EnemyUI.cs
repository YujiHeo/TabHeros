using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [Header("할당 오브젝트(HPBar)")]
    public Image imgCurrentHP;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtHp;

    [Header("할당 오브젝트(Timer)")]
    public GameObject goTimer;
    public Image imgCurrentTimer;
    public TextMeshProUGUI txtTimer;

    public void Init(EnemyDataBase _data)
    {
        txtName.text = _data.enemyName;
        txtHp.text = _data.hp.ToString();
        imgCurrentHP.fillAmount = 1f;
        goTimer.SetActive(false);
    }

    public void SetHPBar(int _maxHP, int _currentHP)
    {
        imgCurrentHP.fillAmount = (float)_currentHP / _maxHP;
        txtHp.text = _currentHP.ToString();
    }

    public void SetTimer(int _timer, int _currentTimer)
    {
        imgCurrentTimer.fillAmount = (float)_currentTimer / _timer;
        txtTimer.text = $"{_currentTimer.ToString("N")}초";
    }

}
