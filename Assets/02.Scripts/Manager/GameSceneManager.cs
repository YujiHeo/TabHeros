using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameSceneManager : Singleton<GameSceneManager>
{
    public GameObject fadeCanvas; // 검은색 화면 이미지
    public Image fadeImage;

    private void Start()
    {
        FadeIn();
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

}
