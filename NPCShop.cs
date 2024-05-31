using UnityEngine;

public class NPCShop : MonoBehaviour
{
    [SerializeField] private GameObject buttonShop;
    [SerializeField] private GameObject shopPanel;

    public void OpenShop()
    {
        shopPanel.SetActive(!shopPanel.active);
        buttonShop.SetActive(!shopPanel.active);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonShop.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonShop.SetActive(false);
        }
    }
}
