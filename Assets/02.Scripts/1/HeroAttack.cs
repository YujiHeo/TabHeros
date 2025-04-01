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
            Debug.Log($"{heroData.heroName}�� �ڵ� ����! ������: {damage}");

            
            string tag = "DefaultEffect";
            switch (heroData.heroName)
            {
                case "5���볪���̰ǿ�":
                    tag = "GWEffect"; break;
                case "�Ȱ��ı��ڱ����":
                    tag = "SHEffect"; break;
                case "���ʺ�����������":
                    tag = "YJEffect"; break;
                case "����ç����������":
                    tag = "JWEffect"; break;
                case "������ǿձ��п�":
                    tag = "HYEffect"; break;
            }

            
            float offsetX = heroData.isFlipped ? -1f : 1f;
            Vector3 spawnPos = transform.position + new Vector3(offsetX, 0f, 0f);
            Quaternion rot = transform.rotation;

           
            GameObject effect = ObjectPoolManager.instance.SpawnFromPool(tag, spawnPos, rot, 1.5f);

            if (effect != null)
            {
                
                Vector3 scale = effect.transform.localScale;
                scale.x = heroData.isFlipped ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
                effect.transform.localScale = scale;

               
                EffectMove moveScript = effect.GetComponent<EffectMove>();
                if (moveScript != null)
                {
                    moveScript.SetDirection(heroData.isFlipped); 
                }
            }
        }
    }
}


