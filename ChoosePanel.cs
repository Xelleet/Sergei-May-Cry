using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePanel : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;

    public void SetButtonsChoose()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.AddListener(delegate { });
        }
    }
}
