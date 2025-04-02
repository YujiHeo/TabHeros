using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataBase", menuName = "NewEnemy")]
public class EnemyDataBase : ScriptableObject
{
    public string enemyName;
    public GameObject outfit; // Enemy의 외형
    public int hp;
    public int gainGold;
    public int upgradePoint;
    public bool isBoss;
    public float clearTime; // 만약 0f 라면 타이머가 없는 일반 몬스터
}
