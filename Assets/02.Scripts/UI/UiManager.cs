using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    //public void MaximizePanel(GameObject panel)
    //{
    //    StartCoroutine(SlideUp(panel));
    //}

    //private IEnumerator SlideUp(GameObject panel)
    //{
    //    RectTransform rectTransform = panel.GetComponent<RectTransform>();
    //    if (rectTransform != null)
    //    {
    //        Vector2 startPos = new Vector2(0, -Screen.height);
    //        Vector2 endPos = Vector2.zero;
    //        float duration = 0.5f; // 애니메이션 지속 시간
    //        float elapsed = 0f;

    //        rectTransform.anchoredPosition = startPos;
    //        panel.SetActive(true);

    //        while (elapsed < duration)
    //        {
    //            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsed / duration);
    //            elapsed += Time.deltaTime;
    //            yield return null;
    //        }

    //        rectTransform.anchoredPosition = endPos;

    //        // 패널을 최대화 상태로 설정
    //        rectTransform.anchorMin = new Vector2(0, 0);
    //        rectTransform.anchorMax = new Vector2(1, 1);
    //        rectTransform.offsetMin = Vector2.zero;
    //        rectTransform.offsetMax = Vector2.zero;
    //    }
    //}
}
