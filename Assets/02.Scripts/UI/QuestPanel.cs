using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private Button okButton;
    [SerializeField] private GameObject questPanel;

    // Start is called before the first frame update
    private void Start()
    {
        okButton.onClick.AddListener(() => CloseQuestPanel(questPanel));
    }

    private void CloseQuestPanel(GameObject panel)
    {
        UiManager.instance.ClosePanel(panel);
    }
}
