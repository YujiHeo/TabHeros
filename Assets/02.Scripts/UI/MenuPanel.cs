using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button statButton;
    [SerializeField] private Button heroButton;
    [SerializeField] private Button invenButton;
    [SerializeField] private Button achieveButton;

    [SerializeField] private GameObject statPanel;
    [SerializeField] private GameObject heroPanel;
    [SerializeField] private GameObject invenPanel;
    [SerializeField] private GameObject achievePanel;

    private GameObject currentOpenPanel = null; // 현재 열려 있는 패널

    private void Start()
    {
        statButton.onClick.AddListener(() => TogglePanel(statPanel));
        heroButton.onClick.AddListener(() => TogglePanel(heroPanel));
        invenButton.onClick.AddListener(() => TogglePanel(invenPanel));
        achieveButton.onClick.AddListener(() => TogglePanel(achievePanel));
    }

    private void TogglePanel(GameObject panel)
    {
        if (currentOpenPanel == panel)
        {
            panel.SetActive(false);
            currentOpenPanel = null;
        }
        else
        {
            // 모든 패널 닫기
            CloseAllPanels();

            // 새 패널 열기
            panel.SetActive(true);
            currentOpenPanel = panel;
        }
    }

    private void CloseAllPanels()
    {
        statPanel.SetActive(false);
        heroPanel.SetActive(false);
        invenPanel.SetActive(false);
        achievePanel.SetActive(false);
    }

}
