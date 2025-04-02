using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDataBase", menuName = "NewStage")]
public class StageDataBase : ScriptableObject
{
    public AudioClip stageBGM;
    public string stageName;
    public int killCountMax;
    public GameObject background; // Stage의 배경
    public List<EnemyDataBase> enemyDatas;
    public EnemyDataBase bossData;
}
