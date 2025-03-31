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

    private Color activeColor = new Color(1f, 0.6f, 0f); // 주황
    private Color inactiveColor = Color.gray;            // 회색

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
            actionButton.GetComponentInChildren<TMP_Text>().text = "에너리어에";
            priceText.text = $"{GetLevelUpCost()} G";
            actionButton.interactable = true;
            actionButton.image.color = player.gold >= GetLevelUpCost() ? activeColor : inactiveColor;
        }
        else
        {
            levelText.text = "Lv.?";
            atkText.text = "?";
            actionButton.GetComponentInChildren<TMP_Text>().text = "해금";

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
                actionButton.image.color = player.gold >= data.unlockPrice ? activeColor : inactiveColor;
            }
        }

        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(() => OnClick());
    }

    private int GetLevelUpCost()
    {
        return heroData.unlockPrice + (heroData.level - 1) * 50;
    }

    public void OnClick()
    {
        if (!heroData.isUnlocked)
        {
            if (player.gold >= heroData.unlockPrice)
            {
                player.gold -= heroData.unlockPrice;
                heroData.isUnlocked = true;
                heroData.level = 1;
                HeroManager.instance.OnHeroUnlocked(heroData.id);
            }
        }
        else
        {
            int cost = GetLevelUpCost();
            if (player.gold >= cost)
            {
                player.gold -= cost;
                heroData.level++;
                Debug.Log($"[레벨업] {heroData.heroName} → Lv.{heroData.level}");
            }
        }

        HeroManager.instance.RefreshAllSlots();
    }
}







