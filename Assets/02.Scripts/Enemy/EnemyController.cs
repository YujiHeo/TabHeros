using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("현재 데이터")]
    private GameObject goOutfit; // Enemy의 외형
    private int currentHp;
    private float currentClearTime;

    [Header("할당 오브젝트")]
    public EnemyUI enemyUI;

    [Header("SO 데이터")]
    EnemyDataBase data;

    public void Start()
    {

    }

    void SetEnemy(EnemyDataBase data)
    {
        this.data = data;

        // prefab이 있다면 하이라이키에서 삭제
        if (goOutfit != null)
        {
            Destroy(goOutfit);
        }
        // 외형을 prefab에 생성
        goOutfit = Instantiate(data.outfit, transform);

        currentHp = data.hp;
        currentClearTime = data.clearTime;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        // TODO : 사망 시
        if (currentHp <= 0)
        {
            currentHp = 0;
        }

    }

}
