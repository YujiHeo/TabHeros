using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponNameText;
    [SerializeField] private Image weaponImage;
    [SerializeField] private TextMeshProUGUI weaponLevel;
    [SerializeField] private TextMeshProUGUI weaponAbility;

    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI upgradePoint;

    [SerializeField] private Button equipButton;
    [SerializeField] private TextMeshProUGUI isEquip;

    private WeaponData weaponData;

    public Player player { get; private set; }

    public void Start()
    {
        if (player == null)
        {
            player = GetComponent<Player>();
        }

        Button upgradeBtn = upgradeButton.GetComponent<Button>();
        upgradeBtn.onClick.AddListener(() => UIInventory.instance.WeaponUpgrade(weaponData));

        Button equipBtn = equipButton.GetComponent<Button>();
        equipBtn.onClick.AddListener(() => UIInventory.instance.WeaponEquipped(weaponData));

        //IsAbleToUpgrading();
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
            weaponLevel.text = weaponData.level.ToString();
            weaponAbility.text = weaponData.ability.ToString();
            upgradePoint.text = weaponData.ownUpgradePoint.ToString();

        }

        else
        {
            weaponNameText.text = "";
            weaponImage.sprite = null;
            weaponLevel.text = "0";
            weaponAbility.text = "0";
            upgradePoint.text = "0";
        }
    }

    /*
    public void IsAbleToUpgrading() //��ȭ �Ұ��� �� ����Ʈ �ؽ�Ʈ�� ���������� ����
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
    */
}
