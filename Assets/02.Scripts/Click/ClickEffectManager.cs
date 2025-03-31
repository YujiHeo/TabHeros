using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

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
            //  UI 위 클릭이면 아무 것도 하지 않음
            if (IsPointerOverUIObject()) return;

            // 이펙트 위치 계산
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            Vector3 particlePos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            particlePos.z = 0;
            particlePos.y += yOffset;

            // 이펙트 생성
            ObjectPoolManager.instance.SpawnFromPool(attackEffectTag, mouseWorldPos, Quaternion.identity, attackEffectLife);
            ObjectPoolManager.instance.SpawnFromPool(particleEffectTag, particlePos, Quaternion.identity, particleEffectLife);

            // 데미지 계산 및 전달
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

    private bool IsPointerOverUIObject()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        return results.Count > 0;
    }
}



