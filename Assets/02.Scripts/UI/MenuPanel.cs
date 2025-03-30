using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button[] menuButtons;
    //[SerializeField] private Button[] maximalizeButtons;
    //[SerializeField] private Button[] minimalizeButtons;
    //[SerializeField] private Button[] closeButtons;
    [SerializeField] private GameObject[] panels; 

    private GameObject currentOpenPanel = null; // ���� ���� �ִ� �г�

    private void Start()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            int index = i;
            menuButtons[i].onClick.AddListener(() => TogglePanel(panels[index]));

        }
    }

    private void TogglePanel(GameObject panel)
    {
        if (currentOpenPanel == panel)
        {
            UiManager.Instance.ClosePanel(panel);
            currentOpenPanel = null;
        }
        else
        {
            // ��� �г� �ݱ�
            CloseAllPanels();

            // �� �г� ����
            panel.SetActive(true);
            currentOpenPanel = panel;
        }
    }

    private void CloseAllPanels()
    {
        foreach (var panel in panels)
        {
            UiManager.Instance.ClosePanel(panel);
        }
    }

}
