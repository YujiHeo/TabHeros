using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScene : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private string nextSceneName = "GameScene";
    [SerializeField] private SceneTransition sceneTransition;

    private void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            SaveLoadManager.instance.InitializeNewGame(); // 데이터 초기화
            SceneTransition.instance.OnPlayButtonClicked(nextSceneName); // 씬 전환
        });
        continueButton.onClick.AddListener(() =>
        {
            SceneTransition.instance.OnPlayButtonClicked(nextSceneName);
        });
    }
}
