using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEffectManager : MonoBehaviour
{
    public string attackEffectTag = "AttackEffect";
    public string particleEffectTag = "ParticleEffect";

    public float attackEffectLife = 1f;
    public float particleEffectLife = 2f;
    public float yOffset = 3f;

    public EnemyController enemyController;
    public Player player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            Vector3 particlePos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            particlePos.z = 0;
            particlePos.y += yOffset;

            // Attack 이펙트
            ObjectPoolManager.Instance.SpawnFromPool(attackEffectTag, mouseWorldPos, Quaternion.identity, attackEffectLife);

            // Particle 이펙트
            ObjectPoolManager.Instance.SpawnFromPool(particleEffectTag, particlePos, Quaternion.identity, particleEffectLife);

            // 데미지 계산
            bool isCritical = Random.value < player.crit / 100f;
            int damage = player.atk;

            if (isCritical)
            {
                damage = Mathf.RoundToInt(damage * (player.critDamage / 100f));
                Debug.Log($" 치명타! 데미지: {damage}");
            }
            else
            {
                Debug.Log($" 타격! 데미지: {damage}");
            }

            enemyController.TakeDamage(damage);
        }
    }
}

