using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScene : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private string nextSceneName = "GameScene";
    [SerializeField] private SceneTransition sceneTransition;

    private void Start()
    {
        continueButton.onClick.AddListener(() =>
        {
            SceneTransition.instance.OnPlayButtonClicked(nextSceneName);
        });
    }
}
