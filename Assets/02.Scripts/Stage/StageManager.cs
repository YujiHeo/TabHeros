using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [Header("현재 데이터")]
    private GameObject goBackground; // Stage의 배경
    private int currentStage;

    [Header("할당 오브젝트")]
    public StageUI stageUI;
    public EnemyController enemyController;

    [Header("SO 데이터")]
    public List<StageDataBase> stageDataBases;

    void Start()
    {
        // prefab이 있다면 하이라이키에서 삭제
        if (goBackground != null)
        {
            Destroy(goBackground);
        }
        // 배경을 prefab에 생성
        goBackground = Instantiate(stageDataBases[0].background, transform);

    }
}
