using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScene : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private string nextSceneName = "GameScene";
    [SerializeField] private SceneTransition sceneTransition;

    private void Start()
    {
        playButton.onClick.AddListener(() => sceneTransition.OnPlayButtonClicked(nextSceneName));
    }
}
