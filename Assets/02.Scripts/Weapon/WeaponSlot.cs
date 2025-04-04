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
    [SerializeField] private TextMeshProUGUI upgradeText;

    [SerializeField] private Button equipButton;
    [SerializeField] private TextMeshProUGUI isEquip;

    private WeaponData weaponData;
    private WeaponSlot weaponSlot;
    private Player player;

    [SerializeField]private PlayerSaveData playerData;
    public void Awake()
    {
        if (player == null)
            player = FindObjectOfType<Player>();

        weaponSlot = GetComponent<WeaponSlot>();

        Button upgradeBtn = upgradeButton.GetComponent<Button>();
        upgradeBtn.onClick.AddListener(() => UIInventory.instance.WeaponUpgrade(player, weaponData, weaponSlot));

        Button equipBtn = equipButton.GetComponent<Button>();
        equipBtn.onClick.AddListener(() => UIInventory.instance.WeaponEquipped(weaponSlot, weaponData));

        playerData = SaveLoadManager.instance.playerData;
        UpdateText();
    }

    public WeaponData GetWeaponData()
    {
        return weaponData;
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


    public void UpdateText()
    {
        Color activeColor;
        Color inactiveColor;
        Color inactiveColorForText;

        ColorUtility.TryParseHtmlString("#F3883D", out activeColor);
        ColorUtility.TryParseHtmlString("#989390", out inactiveColor);

        ColorUtility.TryParseHtmlString("#000000", out inactiveColorForText);

        int upgradePoints = weaponData.ownUpgradePoint;

        upgradeButton.transition = Selectable.Transition.None;

        upgradeButton.image.color = playerData.upgradePoints >= upgradePoints ? activeColor : inactiveColor;
        upgradeText.color = playerData.upgradePoints >= upgradePoints ? inactiveColorForText : activeColor;

        SaveLoadManager.instance.SaveAllData();
    }
}
