using System.Collections;
using UnityEngine;

public class GodLikeAbility : MonoBehaviour
{
    [SerializeField] internal string tag;

    [SerializeField] internal float abilityPower;

    private void Update()
    {
        gameObject.SetActive(FindObjectOfType<PlayerManaManager>().mana > 0);
        //GetComponent<SphereCollider>().enabled = !gameObject.active;
    }

    public void AddHP()
    {
        GetComponentInParent<PlayerHealthManager>().StartCoroutine(GetComponentInParent<PlayerHealthManager>().ChangeHealth(abilityPower, GetComponent<ParticleSystem>().duration));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>())
        {
            if (tag == "DamageGodLikeAbilty")
            {
                other.GetComponent<Entity>().StartCoroutine(other.GetComponent<Entity>().ChangeHealth(abilityPower, GetComponent<ParticleSystem>().duration));
            }
        }
    }
}
