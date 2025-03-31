using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMove : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 1.5f;

    private void OnEnable()
    {
        Invoke(nameof(DisableSelf), lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void DisableSelf()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke(); 
    }
}

