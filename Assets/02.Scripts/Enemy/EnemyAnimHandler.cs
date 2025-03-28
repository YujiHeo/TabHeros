using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimHandler : MonoBehaviour
{
    [Header("현재 데이터")]
    private Animator anim; // Enemy의 외형

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Hurt()
    {
        anim.Play("Hurt", 0, 0f);
    }

    public void Die()
    {
        anim.Play("Die", 0, 0f);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
