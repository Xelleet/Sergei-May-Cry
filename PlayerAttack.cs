using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] internal float radius = 4f;

    [SerializeField] internal protected LayerMask layer;

    [SerializeField] private GameObject[] godLikeEffects; //Или типа того
    [SerializeField] internal GameObject[] godLikeAbilites; //Или типа того v2.0
    [SerializeField] private GameObject[] godLikeTrownAbilites; //Или типа того v3.0

    [SerializeField] internal GameObject currentGodLikeAbilites;

    [SerializeField] internal List<GameObject> weapons;
    
    [SerializeField] internal GameObject currentWeapon;
    [SerializeField] private GameObject currentGodLikeTrownAbility;

    internal int currentGodLikeAbilitiesIndex = 0;

    internal bool isInFight = false;

    private void Awake()
    {
        currentGodLikeAbilites = godLikeAbilites[0];
        currentWeapon = weapons[0];
        currentGodLikeTrownAbility = godLikeTrownAbilites[0];
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<EnemyAttack>() || collider.GetComponent<Boss>())
            {
                isInFight = true;
            }
        }  
        
        Debug.DrawRay(transform.position, new Vector3(0, 0, currentWeapon.GetComponent<Weapon>().radius));
        if (Input.GetKeyDown(KeyCode.Mouse2) && GetComponent<PlayerManaManager>().mana > 0 && !currentGodLikeAbilites.active)
        {
            StartCoroutine(StartAbilites(true, currentGodLikeAbilitiesIndex));
            GetComponent<PlayerManaManager>().StartCoroutine(GetComponent<PlayerManaManager>().ChangeMana(-currentGodLikeAbilites.GetComponent<GodLikeAbility>().abilityPower, currentGodLikeAbilites.GetComponent<ParticleSystem>().duration));
        }
        //if (Input.GetKeyDown(KeyCode.Q) && GetComponent<PlayerManaManager>().mana > 0)
        //{
        //    Instantiate(currentGodLikeTrownAbility, gameObject.transform);
        //    GetComponent<PlayerManaManager>().ChangeMana(-currentGodLikeTrownAbility.GetComponent<GodLikeTrownAbility>().damage);
        //}
    }

    public void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, currentWeapon.GetComponent<Weapon>().radius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.GetComponent<Entity>())
            {
                collider.GetComponent<Entity>().ChangeHealth(currentWeapon.GetComponent<Weapon>().damage);
                // Пока что я это уберу, но добавив массив проблемку мы решить сможем raycast.collider.GetComponent<QuestableEnemy>().ChangeProgress(1); //это счастье можно будет потом переделать, создав в questableEnemy массив или типа того, хотя если честно хз как это грамотно реализовать
            }
        }
    }

    public void StartEffect(bool isStart, int index)
    {

    }

    private void KickAbility()
    {
        
    }

    private IEnumerator StartAbilites(bool isStart, int index)
    {
        godLikeAbilites[index].SetActive(isStart);

        if (godLikeAbilites[index].GetComponent<GodLikeAbility>().tag == "HealingGodLikeAbility") godLikeAbilites[index].GetComponent<GodLikeAbility>().AddHP();

        currentGodLikeAbilites = godLikeAbilites[index];

        yield return new WaitForSeconds(godLikeAbilites[index].GetComponent<ParticleSystem>().duration);
        godLikeAbilites[index].SetActive(false);
    }
}
