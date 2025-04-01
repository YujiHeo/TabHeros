using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroSlot : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;
    public TMP_Text levelText;
    public TMP_Text atkText;
    public TMP_Text priceText;
    public Button actionButton;

    private HeroData heroData;
    private Player player;

    private Color activeColor = new Color(1f, 0.6f, 0f); // ��Ȳ
    private Color inactiveColor = Color.gray;            // ȸ��

    private void Awake()
    {
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(OnClick);
    }

    public void SetData(HeroData data, bool isLocked, Player playerRef)
    {
        heroData = data;
        player = playerRef;

        icon.sprite = data.heroIcon;
        nameText.text = data.heroName;

        if (data.isUnlocked)
        {
            levelText.text = $"Lv.{data.level}";
            atkText.text = $" {data.baseDamage + (data.level - 1) * 10}";
            actionButton.GetComponentInChildren<TMP_Text>().text = "������";
            priceText.text = $"{GetLevelUpCost()} G";
            actionButton.interactable = true;
            actionButton.image.color = SaveLoadManager.instance.playerData.gold >= GetLevelUpCost() ? activeColor : inactiveColor;
        }
        else
        {
            levelText.text = "Lv.?";
            atkText.text = "?";
            actionButton.GetComponentInChildren<TMP_Text>().text = "�ر�";

            if (isLocked)
            {
                priceText.text = "?G";
                actionButton.interactable = false;
                actionButton.image.color = inactiveColor;
            }
            else
            {
                priceText.text = $"{data.unlockPrice} G";
                actionButton.interactable = true;
                actionButton.image.color = SaveLoadManager.instance.playerData.gold >= data.unlockPrice ? activeColor : inactiveColor;
            }
        }
    }

    private int GetLevelUpCost()
    {
        return heroData.unlockPrice + (heroData.level - 1) * 50;
    }

    public void OnClick()
    {
        if (heroData == null || player == null) return;

        if (!heroData.isUnlocked)
        {
            if (SaveLoadManager.instance.playerData.gold >= heroData.unlockPrice)
            {
                SaveLoadManager.instance.playerData.gold -= heroData.unlockPrice;
                heroData.isUnlocked = true;
                heroData.level = 1;
                HeroManager.instance.OnHeroUnlocked(heroData.id);
            }
        }
        else
        {
            int cost = GetLevelUpCost();
            if (SaveLoadManager.instance.playerData.gold >= cost)
            {
                SaveLoadManager.instance.playerData.gold -= cost;
                heroData.level++;
                Debug.Log($"[������] {heroData.heroName} �� Lv.{heroData.level}");
            }
        }

        HeroManager.instance.RefreshAllSlots();
    }
}








