using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAttack : MonoBehaviour
{
    public GameObject effectPrefab;
    public float critChance = 0.3f;

    public Color normalColor = Color.white;
    public Color critColor = Color.red;

    public float normalScale = 1f;
    public float critScale = 1.8f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            bool isCritical = Random.value < critChance;

            GameObject effect = Instantiate(effectPrefab, pos, Quaternion.identity);

            // 크기 조절
            float scale = isCritical ? critScale : normalScale;
            effect.transform.localScale = Vector3.one * scale;

            // 색상 조절
            SpriteRenderer sr = effect.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = isCritical ? critColor : normalColor;
            }

            // 자동 제거
            Destroy(effect, 1f);

            Debug.Log(isCritical ? " 치명타 발생!" : "타격");
        }
    }
}


