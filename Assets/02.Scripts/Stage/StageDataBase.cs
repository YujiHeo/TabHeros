using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDataBase", menuName = "NewStage")]
public class StageDataBase : ScriptableObject
{
    public string stageName;
    public int killCountMax;
    public GameObject background; // Stage의 배경
    public EnemyDataBase enemyData;
    public EnemyDataBase bossData;
}
