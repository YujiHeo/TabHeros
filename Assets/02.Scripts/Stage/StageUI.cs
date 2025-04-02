using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    public TextMeshProUGUI txtStageName;
    public TextMeshProUGUI txtKillCount;
    public Button btnBossJoin;
    public Button btnBossQuit;

    public void Init(StageDataBase _data, int _currentKillCount)
    {
        txtStageName.text = _data.stageName;
        txtKillCount.text = $"{_currentKillCount}/{_data.killCountMax}"; ;
        btnBossJoin.gameObject.SetActive(false);
        btnBossQuit.gameObject.SetActive(false);
    }

    public void SetEnemyCount(int _maxKillCountMax, int _currentKillCount)
    {
        txtKillCount.text = $"{_currentKillCount}/{_maxKillCountMax}";
    }

    // 보스방 입장 가능 할 시 활성화
    public void SetBossJoinActive(bool _isStageBoss)
    {
        btnBossJoin.gameObject.SetActive(_isStageBoss);
    }

    // 보스 방 입장 시 보스방 나가기 버튼 활성화
    public void SetBossQuitActive(bool _isJoinBoss)
    {
        btnBossQuit.gameObject.SetActive(_isJoinBoss);
    }
}
