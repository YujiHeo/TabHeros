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
            Debug.Log($"{heroData.heroName}가 자동 공격! 데미지: {damage}");

            
            string tag = "DefaultEffect";
            switch (heroData.heroName)
            {
                case "5톤통나무이건우":
                    tag = "GWEffect"; break;
                case "안경파괴자김상현":
                    tag = "SHEffect"; break;
                case "왕초보팀장허유지":
                    tag = "YJEffect"; break;
                case "슈퍼챌린저박진우":
                    tag = "JWEffect"; break;
                case "브론즈의왕김학영":
                    tag = "HYEffect"; break;
            }

            // 이펙트 생성 위치 결정 (영웅이 바라보는 방향에 따라 생성 위치 조정)
            float offsetX = heroData.isFlipped ? -1f : 1f;
            Vector3 spawnPos = transform.position + new Vector3(offsetX, 0f, 0f);
            Quaternion rot = transform.rotation;

           // 이펙트 설정
            GameObject effect = ObjectPoolManager.instance.SpawnFromPool(tag, spawnPos, rot, 1.5f);

            if (effect != null)
            {
                //이펙트 좌우 반전 (스프라이트 기준)
                Vector3 scale = effect.transform.localScale;
                scale.x = heroData.isFlipped ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
                effect.transform.localScale = scale;

                // 이펙트 이동 방향 설정
                EffectMove moveScript = effect.GetComponent<EffectMove>();
                if (moveScript != null)
                {
                    moveScript.SetDirection(heroData.isFlipped); 
                }
            }
        }
    }
}


