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
    public string critEffectTag = "CritEffect"; 
    public float critEffectLife = 2f;

    public EnemyController enemyController;
    public Player player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            if (IsPointerOverUIObject()) return;

            
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            Vector3 particlePos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            particlePos.z = 0;
            particlePos.y += yOffset;

            
            ObjectPoolManager.instance.SpawnFromPool(attackEffectTag, mouseWorldPos, Quaternion.identity, attackEffectLife);
            ObjectPoolManager.instance.SpawnFromPool(particleEffectTag, particlePos, Quaternion.identity, particleEffectLife);

            
            bool isCritical = Random.value < player.crit / 100f;
            int damage = player.atk;

            if (isCritical)
            {
                damage = Mathf.RoundToInt(damage * (player.critDamage / 100f));
                Debug.Log($"치명타! 데미지: {damage}");                
                ObjectPoolManager.instance.SpawnFromPool(critEffectTag, particlePos, Quaternion.identity, critEffectLife);        
                SoundManager.instance.PlaySFX("Jump");
            }
            else
            {
                Debug.Log($"타격! 데미지: {damage}");             
                ObjectPoolManager.instance.SpawnFromPool(particleEffectTag, particlePos, Quaternion.identity, particleEffectLife);               
                SoundManager.instance.PlaySFX("Jump3");
            }



            AchievementManager.instance.IncreaseAchievementProgress(AchievementType.Click, 1);
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



