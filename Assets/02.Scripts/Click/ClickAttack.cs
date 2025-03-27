using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAttack : MonoBehaviour
{
    public GameObject effectPrefab; // Ŭ�� �� ������ ����Ʈ ������

    void Update()
    {
        

        // ���콺 Ŭ�� ó�� 
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

        Debug.Log("������ġ: " + position);
        
    }
}

