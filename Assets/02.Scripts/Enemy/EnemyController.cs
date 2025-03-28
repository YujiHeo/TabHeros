using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("현재 데이터")]
    private GameObject goOutfit; // Enemy의 외형
    private EnemyAnimHandler animHandler; // Enemy의 외형
    private int currentHP;
    private float currentClearTime;

    [Header("할당 오브젝트")]
    public EnemyUI enemyUI;

    [Header("SO 데이터")]
    EnemyDataBase data;

    public void SetEnemy(EnemyDataBase _data)
    {
        this.data = _data;

        // prefab이 있다면 하이라이키에서 삭제
        if (goOutfit != null)
        {
            Destroy(goOutfit);
        }
        // 외형을 prefab에 생성
        goOutfit = Instantiate(data.outfit, transform);
        animHandler = goOutfit.GetComponent<EnemyAnimHandler>();

        currentHP = data.hp;
        currentClearTime = data.clearTime;
        enemyUI.Init(data);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int _damage)
    {
        if (currentHP <= 0)
        {
            Debug.Log("이미 사망했습니다.");
            return;
        }

        currentHP -= _damage;
        enemyUI.SetHPBar(data.hp, currentHP);

        if (currentHP <= 0)
        {
            // TODO : 사망하는 연출
            currentHP = 0;
            animHandler.Die();
            StageManager.instance.EnemyKill();
        }
        else
        {
            // TODO : 데미지 입는 연출
            animHandler.Hurt();
        }

    }

}
