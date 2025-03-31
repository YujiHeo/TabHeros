using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private HeroData heroData;
    private float timer;

    public void Init(HeroData data)
    {
        heroData = data;
    }

    private void Update()
    {
        // 히어로가 해금되지 않았거나 데이터가 없으면 공격 안 함
        if (heroData == null || !heroData.isUnlocked) return;

        timer += Time.deltaTime;

        if (timer >= heroData.attackInterval)
        {
            timer = 0f;
            Attack();
        }
    }

    private void Attack()
    {
        int damage = heroData.baseDamage + (heroData.level - 1) * 10;
        EnemyController target = FindObjectOfType<EnemyController>();
        if (target != null)
        {
            target.TakeDamage(damage);
            Debug.Log($"{heroData.heroName}가 자동 공격! 데미지: {damage}");
        }
    }
}

