using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [Header("현재 데이터")]
    private GameObject goBackground; // Stage의 배경
    private int currentStage;
    private Dictionary<int, int> killCount = new Dictionary<int, int>(); // stage와 count
    private int clearStage;

    [Header("할당 오브젝트")]
    public StageUI stageUI;
    public EnemyController enemyController;

    [Header("SO 데이터")]
    public List<StageDataBase> stageDataBases;

    void Start()
    {
        SetStage(0);
    }

    public void SetStage(int _stage)
    {
        currentStage = Math.Clamp(_stage, 0, stageDataBases.Count);

        // prefab이 있다면 하이라이키에서 삭제
        if (goBackground != null)
        {
            Destroy(goBackground);
        }
        // 배경을 prefab에 생성
        goBackground = Instantiate(stageDataBases[currentStage].background, transform);

        // 적 설정
        enemyController.SetEnemy(stageDataBases[currentStage].enemyData);

        // 없다면 현재 스테이지의 킬 수 설정
        if (!killCount.ContainsKey(currentStage))
        {
            killCount.Add(currentStage, 0);
        }

        stageUI.SetEnemyCount(stageDataBases[currentStage].killCountMax, killCount[currentStage]);
    }


    public void EnemyKill()
    {
        // 킬 수 증가
        killCount[currentStage]++;
        stageUI.SetEnemyCount(stageDataBases[currentStage].killCountMax, killCount[currentStage]);

        // 적 설정
        Invoke("CreateEnemy", 0.5f);
    }

    public void CreateEnemy()
    {
        enemyController.SetEnemy(stageDataBases[currentStage].enemyData);
    }

    public void StartBoss()
    {

    }
}
