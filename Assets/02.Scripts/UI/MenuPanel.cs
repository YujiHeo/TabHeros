using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button[] menuButtons;
    [SerializeField] private Button[] closeButtons;
    [SerializeField] private GameObject[] panels; 

    private GameObject currentOpenPanel = null; // ���� ���� �ִ� �г�

    private void Start()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            int index = i;
            menuButtons[i].onClick.AddListener(() => ToggleMenuPanel(panels[index]));
            closeButtons[i].onClick.AddListener(() => ToggleMenuPanel(panels[index]));
        }

    }

    private void ToggleMenuPanel(GameObject panel)
    {
        if (currentOpenPanel == panel)
        {
            UiManager.instance.ClosePanel(panel);
            currentOpenPanel = null;
        }
        else
        {
            // ��� �г� �ݱ�
            CloseAllMenuPanel();

            // �� �г� ����
            UiManager.instance.OpenPanel(panel);
            currentOpenPanel = panel;
        }
    }

    private void CloseAllMenuPanel()
    {
        foreach (var panel in panels)
        {
            UiManager.instance.ClosePanel(panel);
        }
    }

}
