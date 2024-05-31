using UnityEngine;
using System.Collections.Generic;
using System;
using System.Reflection;

public class SpecialEvent : MonoBehaviour
{
    [SerializeField] private List<Event> events;

    [SerializeField] private int index;
    [SerializeField] private string method;

    private void GiveMoney()
    {
        FindObjectOfType<PlayerCurrency>().ChangeCoinsCount(events[index].Coins);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke(method, 0f);
            Destroy(gameObject);
        }
    }
}

[Serializable]
public class Event
{
    public float Coins;
}
