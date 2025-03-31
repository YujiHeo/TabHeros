using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private HeroData heroData;
    private float timer;

    public GameObject attackEffectPrefab;

    public void Init(HeroData data)
    {
        heroData = data;
    }

    private void Update()
    {
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

           
            Quaternion rotation = heroData.isFlipped ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

           
            ObjectPoolManager.instance.SpawnFromPool("GWEffect", transform.position, rotation, 1.5f);
            ObjectPoolManager.instance.SpawnFromPool("HYEffect", transform.position, rotation, 1.5f);
            ObjectPoolManager.instance.SpawnFromPool("SHEffect", transform.position, rotation, 1.5f);
            ObjectPoolManager.instance.SpawnFromPool("JWEffect", transform.position, rotation, 1.5f);
            ObjectPoolManager.instance.SpawnFromPool("YJEffect", transform.position, rotation, 1.5f);
        }
    }
}

