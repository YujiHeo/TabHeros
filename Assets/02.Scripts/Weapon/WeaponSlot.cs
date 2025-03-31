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
    private WeaponSlot weaponSlot;
    private Player player;

    public void Start()
    {
        if (player == null)
            player = FindObjectOfType<Player>();

        weaponSlot = GetComponent<WeaponSlot>();

        //if (weaponData == null)
            //weaponData = Resources.Load<WeaponData>("ATKUP");

        Button upgradeBtn = upgradeButton.GetComponent<Button>();
        upgradeBtn.onClick.AddListener(() => UIInventory.instance.WeaponUpgrade(player, weaponData));

        Button equipBtn = equipButton.GetComponent<Button>();
        equipBtn.onClick.AddListener(() => UIInventory.instance.WeaponEquipped(weaponSlot, weaponData));

        //IsAbleToUpgrading(player, weaponData);
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
            
            weaponLevel.text = weaponData.level.ToString();
            weaponAbility.text = weaponData.ability.ToString();
            upgradePoint.text = weaponData.ownUpgradePoint.ToString();

            weaponImage.sprite = weaponData.Icon;

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

    public void AlreadyEquipped()
    {
         //equipButton = GetComponent<Button>().colors;
        //equipButton.normalColor = Color.red;
        //GetComponent<Button>().colors = equipButton;
    }

    /*
    public void IsAbleToUpgrading(Player player, WeaponData weaponData) //강화 불가능 시 포인트 텍스트를 붉은색으로 변경
    {
        if (player == null || weaponData == null) return;

        if (GameManager.player.upgradePoints < weaponData.ownUpgradePoint)
        {
            upgradePoint.color = Color.red;
        }
        else
        {
            upgradePoint.color = Color.white; // 원래 색으로 되돌리기
        }
    }
    */
    
}
