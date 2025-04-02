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
            SceneTransition.instance.OnPlayButtonClicked(nextSceneName);
        });
        continueButton.onClick.AddListener(() =>
        {
            SceneTransition.instance.OnContinueButtonClicked(nextSceneName);
        });
    }
}
