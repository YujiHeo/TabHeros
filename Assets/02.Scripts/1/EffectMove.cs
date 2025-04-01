using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMove : MonoBehaviour
{
    public float speed = 2f;
    public float lifeTime = 0.7f;

    private int direction = 1;

    private void OnEnable()
    {
        Invoke(nameof(DisableSelf), lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }

    
    public void SetDirection(bool isFlipped)
    {
        direction = isFlipped ? -1 : 1;
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



