using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UiManager uiManager => UiManager.Instance; // �̱��� ���� ���

    protected abstract UiState GetUIState();

    public void SetActive(UiState state)
    {
        bool isActive = GetUIState() == state;

        Debug.Log($"{this.name} SetActive({state}) -> {isActive}"); // ����� �߰�
        this.gameObject.SetActive(isActive);
    }
}