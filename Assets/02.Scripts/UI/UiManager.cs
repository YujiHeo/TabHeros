using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;

    [SerializeField] private List<GameObject> panels; // 모든 UI 패널 리스트
    private GameObject currentOpenPanel = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void TogglePanel(GameObject panel)
    {
        if (currentOpenPanel == panel)
        {
            panel.SetActive(false);
            currentOpenPanel = null;
        }
        else
        {
            CloseAllPanels();
            panel.SetActive(true);
            currentOpenPanel = panel;
        }
    }

    public void CloseAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        currentOpenPanel = null;
    }
}
