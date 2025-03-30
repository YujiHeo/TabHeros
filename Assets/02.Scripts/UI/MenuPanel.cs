using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject[] panels; 

    private GameObject currentOpenPanel = null; // ���� ���� �ִ� �г�

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => TogglePanel(panels[index]));

        }
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
            panel.SetActive(false);
        }
    }

}
