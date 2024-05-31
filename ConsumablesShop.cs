using UnityEngine;
using System;

public class ConsumablesShop : MonoBehaviour
{
    private float changeCount;
    private float cost;

    public void ChangeCount(float changeCount)
    {
        this.changeCount = changeCount;
    }

    public void ChangeCost(float cost)
    {
        this.cost = cost;
    }

    public void ChangeFAC()
    {
        if (FindObjectOfType<PlayerCurrency>().coins >= cost)
        {
            FindObjectOfType<PlayerHealthManager>().faks.Add(changeCount);
            FindObjectOfType<PlayerCurrency>().coins -= cost;
        }
    }

    public void ChangeManaReducer()
    {
        if (FindAnyObjectByType<PlayerManaManager>().mana < 100)
        {
            FindObjectOfType<PlayerManaManager>().mana += cost;
            FindObjectOfType<PlayerCurrency>().coins -= cost;
        }
    }
}
