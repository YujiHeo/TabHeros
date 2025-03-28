using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDataBase", menuName = "NewStage")]
public class StageDataBase : ScriptableObject
{
    public GameObject background; // Stage의 배경
    public EnemyDataBase enemyDatas;
    public EnemyDataBase bossData;
}
