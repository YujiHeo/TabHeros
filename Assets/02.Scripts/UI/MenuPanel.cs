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

    private void Start()
    {
        statButton.onClick.AddListener(() => UIManager.Instance.TogglePanel(statPanel));
        heroButton.onClick.AddListener(() => UIManager.Instance.TogglePanel(heroPanel));
        invenButton.onClick.AddListener(() => UIManager.Instance.TogglePanel(invenPanel));
        achieveButton.onClick.AddListener(() => UIManager.Instance.TogglePanel(achievePanel));
    }
}
