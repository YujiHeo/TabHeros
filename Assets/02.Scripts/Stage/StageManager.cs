using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [Header("현재 데이터")]
    public GameObject goBackground; // Stage의 배경
    public int currentStage;
    public Dictionary<int, int> killCount = new Dictionary<int, int>(); // stage와 count
    public int clearStage = -1; // 클리어 한 스테이지가 아니라면 바로 보스방 진입

    [Header("할당 오브젝트")]
    public StageUI stageUI;
    public EnemyController enemyController;

    [Header("SO 데이터")]
    public List<StageDataBase> stageDataBases;

    void Start()
    {
        stageUI.btnBossJoin.onClick.AddListener(OnClickBossJoin);
        stageUI.btnBossQuit.onClick.AddListener(OnClickBossQuit);
        SetStage(currentStage);
    }

    public void SetStage(int _stage)
    {
        currentStage = Math.Clamp(_stage, 0, stageDataBases.Count - 1);

        // prefab이 있다면 하이라이키에서 삭제
        if (goBackground != null)
        {
            Destroy(goBackground);
        }
        // 배경을 prefab에 생성
        goBackground = Instantiate(stageDataBases[currentStage].background, transform);

        // 적 설정
        CreateEnemy();

        // 없다면 현재 스테이지의 킬 수 설정
        if (!killCount.ContainsKey(currentStage))
        {
            killCount.Add(currentStage, 0);
        }
        stageUI.Init(stageDataBases[currentStage], killCount[currentStage]);

        // 보스 버튼 활성화
        if (killCount[currentStage] >= stageDataBases[currentStage].killCountMax)
        {
            stageUI.SetBossJoinActive(true);
        }
    }


    public void EnemyKill()
    {
        // 킬 수 증가
        killCount[currentStage]++;
        SaveLoadManager.instance.SaveAllData();
        stageUI.SetEnemyCount(stageDataBases[currentStage].killCountMax, killCount[currentStage]);

        // 적 설정 (바로 보스 소환) - 클리어가 안 된 스테이지라면
        if (killCount[currentStage] >= stageDataBases[currentStage].killCountMax && clearStage < currentStage)
        {
            clearStage = currentStage;
            stageUI.SetBossJoinActive(true);
            stageUI.SetBossQuitActive(true);
            CreateBoss();
            // Invoke("CreateBoss", 0.5f);
            return;
        }

        // 적 설정 (보스 소환 가능) - 이미 클리어가 된 스테이지 라면
        if (killCount[currentStage] >= stageDataBases[currentStage].killCountMax)
        {
            stageUI.SetBossJoinActive(true);
            stageUI.SetBossQuitActive(false);
            CreateEnemy();
            // Invoke("CreateEnemy", 0.5f);
            return;
        }

        // 적 설정 (보스 소환 X)
        stageUI.SetBossJoinActive(false);
        stageUI.SetBossQuitActive(false);
        CreateEnemy();
        // Invoke("CreateEnemy", 0.5f);

    }

    public void BossKill()
    {
        SetStage(currentStage + 1);
        // StartCoroutine(StartAction(() => SetStage(currentStage + 1), 0.5f));
    }

    public void BossTimeout()
    {
        SetStage(currentStage);
    }

    public IEnumerator StartAction(Action _action, float _time)
    {
        yield return new WaitForSeconds(_time);
        _action();
    }

    public void CreateEnemy()
    {
        // 배열 중 한개 랜덤으로 가져옴
        enemyController.SetEnemy(stageDataBases[currentStage].enemyDatas[UnityEngine.Random.Range(0, stageDataBases[currentStage].enemyDatas.Count)]);
    }

    public void CreateBoss()
    {
        enemyController.SetEnemy(stageDataBases[currentStage].bossData);
    }


    public void OnClickBossJoin()
    {
        stageUI.SetBossJoinActive(false);
        stageUI.SetBossQuitActive(true);
        CreateBoss();
    }
    public void OnClickBossQuit()
    {
        stageUI.SetBossJoinActive(true);
        stageUI.SetBossQuitActive(false);
        CreateEnemy();
    }
}
