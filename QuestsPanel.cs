using UnityEngine;
using UnityEngine.UI;

public class QuestsPanel : MonoBehaviour
{
    [SerializeField] private GameObject questsPanel;

    [SerializeField] private Text questText; //Пока что только объект, потом нужно будет добавить массив

    public void ShowPanel()
    {
        questsPanel.SetActive(!questsPanel.active);
    }

    public void SetText(string text)
    {
        questText.text = text;
    }
}
