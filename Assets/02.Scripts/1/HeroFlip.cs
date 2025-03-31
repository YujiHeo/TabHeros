using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlip : MonoBehaviour
{
    [SerializeField] private bool flipLeft = true;

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.flipX = flipLeft; 
        }
    }
}

