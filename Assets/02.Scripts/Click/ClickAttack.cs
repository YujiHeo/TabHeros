using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAttack : MonoBehaviour
{
    public GameObject effectPrefab; // 클릭 시 생성할 이펙트 프리팹

    void Update()
    {
        

        // 마우스 클릭 처리 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f;
            AttackAtPosition(clickPosition);
        }
    }

    void AttackAtPosition(Vector3 position)
    {
        if (effectPrefab != null)
        {
            Instantiate(effectPrefab, position, Quaternion.identity);
        }

        Debug.Log("공격위치: " + position);
        
    }
}

