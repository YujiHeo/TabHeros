using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("현재 데이터")]
    private GameObject goOutfit; // Enemy의 외형
    private EnemyAnimHandler animHandler; // Enemy의 외형
    private int currentHP;
    private IEnumerator coroutineBossTimer;
    private IEnumerator coroutineWait;

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
        enemyUI.Init(data);

        if (data.isBoss) StartBossTimer();
        StopWaitAction();
    }

    public void StartBossTimer()
    {
        StopBossTimer();
        coroutineBossTimer = CoroutineBossTimer();
        StartCoroutine(coroutineBossTimer);
    }

    public void StopBossTimer()
    {
        if (coroutineBossTimer != null)
        {
            StopCoroutine(coroutineBossTimer);
            coroutineBossTimer = null;
        }
    }

    public IEnumerator CoroutineBossTimer()
    {
        float totalTime = data.clearTime;
        float currentTime = data.clearTime;

        while (0f < currentTime)
        {
            enemyUI.SetTimer(totalTime, currentTime);
            currentTime -= Time.deltaTime;
            yield return null;
        }

        StageManager.instance.BossTimeout();
    }

    public void TakeDamage(int _damage)
    {
        if (currentHP <= 0)
        {
            Debug.Log("이미 사망했습니다.");
            return;
        }

        currentHP -= _damage;
        if (currentHP <= 0) currentHP = 0;
        enemyUI.SetHPBar(data.hp, currentHP, _damage);

        if (currentHP <= 0)
        {
            // TODO : 사망하는 연출
            currentHP = 0;
            animHandler.Die();
            Die();
        }
        else
        {
            // TODO : 데미지 입는 연출
            animHandler.Hurt();
        }
    }

    public void Die()
    {
        if (data.isBoss)
        {
            StopBossTimer();
            StopWaitAction();
            coroutineWait = StartAction(StageManager.instance.BossKill, 0.5f);
            StartCoroutine(coroutineWait);
        }
        else
        {
            StopWaitAction();
            coroutineWait = StartAction(StageManager.instance.EnemyKill, 0.5f); // 타이머 확인해보기
            StartCoroutine(coroutineWait);
        }
    }


    public IEnumerator StartAction(Action _action, float _time)
    {

        yield return new WaitForSeconds(_time);
        _action();
    }

    public void StopWaitAction()
    {
        if (coroutineWait != null)
        {
            StopCoroutine(coroutineWait);
            coroutineWait = null;
        }
    }
}
