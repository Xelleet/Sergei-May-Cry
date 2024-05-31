using UnityEngine;

public class BlacksmithShop : MonoBehaviour
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

    public void ChangeDamage()
    {
        if (FindObjectOfType<PlayerCurrency>().coins >= cost)
        {
            FindObjectOfType<PlayerAttack>().currentWeapon.GetComponent<Weapon>().damage += changeCount;
            FindObjectOfType<PlayerCurrency>().coins -= cost;
        }
    }

    public void ChangeRadius()
    {
        if (FindObjectOfType<PlayerCurrency>().coins >= cost)
        {
            FindObjectOfType<PlayerAttack>().radius += changeCount;
            FindObjectOfType<PlayerCurrency>().coins -= cost;
        }
    }
}
