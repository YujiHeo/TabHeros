using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponNameText;
    [SerializeField] private Image weaponImage;
    [SerializeField] private int weaponLevel;
    [SerializeField] private int weaponAbility;

    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI upgradePoint;

    [SerializeField] private Button equipButton;
    [SerializeField] private TextMeshProUGUI isEquip;

    private WeaponData weaponData;

    static Player player;

    public void Start()
    {
        Button upgradeBtn = upgradeButton.GetComponent<Button>();
        upgradeBtn.onClick.AddListener(() => UIInventory.instance.WeaponUpgrade(weaponData));

        Button equipBtn = equipButton.GetComponent<Button>();
        equipBtn.onClick.AddListener(() => UIInventory.instance.WeaponEquipped(weaponData));

        IsAbleToUpgrading();
    }

    public void SetItem(WeaponData weapon)
    {
        weaponData = weapon;
        RefreshUI();
    }


    public void RefreshUI()
    {
        if (weaponData != null)
        {
            weaponNameText.text = weaponData.name;
            weaponImage.sprite = weaponData.Icon;
            weaponLevel = weaponData.level;
            weaponAbility = weaponData.ability;

        }

        else
        {
            weaponNameText.text = "";
            weaponImage.sprite = null;
            weaponLevel = 0;
            weaponAbility = 0;
        }
    }

    public void IsAbleToUpgrading() //강화 불가능 시 포인트 텍스트를 붉은색으로 변경
    {
        if (player.upgradePoints < weaponData.ownUpgradePoint)
        {
            upgradePoint.color = Color.red;
        }

        else
        {
            return;
        }
    }
}
