using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickParticle : MonoBehaviour
{
    public GameObject effectPrefab;
    public float yOffset = 3f;
    public float lifeTime = 2f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            pos.z = 0;
            pos.y += yOffset;

            GameObject effect = Instantiate(effectPrefab, pos, Quaternion.identity);
            Destroy(effect, lifeTime);
        }
    }
}


