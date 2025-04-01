using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : Singleton<SceneTransition>
{
    public GameObject fadeCanvas;
    public Image fadeImage;

    private void Awake()
    {
        if (fadeCanvas == null)
        {
            fadeCanvas = GameObject.Find("FadeCanvas");
        }

        if (fadeImage == null)
        {
            fadeImage = fadeCanvas.GetComponentInChildren<Image>();
        }

        fadeCanvas.SetActive(false);
    }

    private void Start()
    {
        FadeIn();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "StartScene")
        {
            Destroy(gameObject);
        }
    }
    public void OnPlayButtonClicked(string sceneName)
    {
        fadeCanvas.gameObject.SetActive(true);
        FadeOutAndLoadScene(sceneName);
    }

    public void FadeOutAndLoadScene(string sceneName)
    {
        fadeImage.DOFade(1, 1f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }

    public void FadeIn()
    {
        fadeImage.color = new Color(0, 0, 0, 1);
        fadeImage.DOFade(0, 1f).SetEase(Ease.InOutQuad);
    }

    public void FadeOut(Action onComplete = null)
    {
        fadeImage.DOFade(1, 5f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }

}
