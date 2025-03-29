using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UiManager uiManager => UiManager.Instance; // ½Ì±ÛÅæ Á¢±Ù ¹æ½Ä

    protected abstract UiState GetUIState();

    public void SetActive(UiState state)
    {
        bool isActive = GetUIState() == state;

        Debug.Log($"{this.name} SetActive({state}) -> {isActive}"); // µð¹ö±ë Ãß°¡
        this.gameObject.SetActive(isActive);
    }
}