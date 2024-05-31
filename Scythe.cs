using System.Collections;
using UnityEngine;

public class Scythe : Weapon
{
    [SerializeField] private int rarity;

    private void Awake()
    {
        StartCoroutine(ChangeDamage());
    }

    public IEnumerator ChangeDamage()
    {
        while (true)
        {
            Debug.Log(Random.Range(0, rarity));
            yield return new WaitForSeconds(1);
            if (Random.Range(0, rarity) == 2)
            {
                damage = 40;
                yield return new WaitForSeconds(3);
                damage = 30;
            }
        }
    }
}
