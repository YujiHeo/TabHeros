using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField] private GameObject currentWeaponImage;

    void Start()
    {
        /*
        Sprite currentIcon = Resources.Load<Sprite>("NomalSword");

        Image iconComponent = currentWeaponImage.GetComponent<Image>();
        iconComponent.sprite = currentIcon;
        */
    }

    public void PopUpWeapon()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
