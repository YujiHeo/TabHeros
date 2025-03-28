using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAttack : MonoBehaviour
{
    public GameObject effectPrefab;
    public float critChance = 0.3f;

    public EnemyController enemyController; //  공격 대상
    public Player player;                   //  플레이어 스탯

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UI 위 클릭 시 무시
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            bool isCritical = Random.value < critChance;

            GameObject effect = Instantiate(effectPrefab, pos, Quaternion.identity);
            Destroy(effect, 1f);

            int damage = player.atk;
            if (isCritical)
            {
                damage = Mathf.RoundToInt(damage * (player.critDamage / 100f));
                Debug.Log(" 치명타! ");
            }
            else
            {
                Debug.Log(" 타격!");
            }

            enemyController.TakeDamage(damage);
        }
    }
}


