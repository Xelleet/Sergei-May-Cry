using UnityEngine;
using System;

public class FirstAndKit : MonoBehaviour
{
    [SerializeField] private float cost = 10f;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(gameObject.name) && PlayerPrefs.GetString("Entity") == "Yes") Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthManager>().faks.Add(cost);
            other.GetComponent <PlayerHealthManager>().faksAmount.text = other.GetComponent<PlayerHealthManager>().faks.Count.ToString();

            PlayerPrefs.SetFloat("FAKS" + Convert.ToString(other.GetComponent<PlayerHealthManager>().faks.Count - 1), cost);
            PlayerPrefs.SetInt("FAKSCount", other.GetComponent<PlayerHealthManager>().faks.Count);
            PlayerPrefs.SetInt(gameObject.name, 1);

            Destroy(gameObject);
        }
    }
}
