using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public abstract class BaseUi : MonoBehaviour
//{
//    protected UiManager uiManager => UiManager.Instance;

//    protected abstract UiState GetUIState(); // 현재 Ui 상태 반환

//    public void SetActive(UiState state)
//    {
//        bool isActive = GetUIState() == state;

//        Debug.Log($"{this.name} SetActive({state}) -> {isActive}"); // 디버깅 추가
//        this.gameObject.SetActive(isActive);
//    }
//}