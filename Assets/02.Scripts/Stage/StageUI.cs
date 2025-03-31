using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    public TextMeshProUGUI txtStageName;
    public TextMeshProUGUI txtKillCount;
    public Button btnBossChallenge;

    public void Init(StageDataBase _data)
    {
        txtStageName.text = _data.stageName;
        txtKillCount.text = _data.killCountMax.ToString();
        btnBossChallenge.gameObject.SetActive(false);
    }

    public void SetEnemyCount(int _maxKillCountMax, int _currentKillCount)
    {
        txtKillCount.text = $"{_currentKillCount}/{_maxKillCountMax}";
    }

    public void SetBossActive(bool _isStageClear)
    {
        btnBossChallenge.gameObject.SetActive(true);
    }
}
