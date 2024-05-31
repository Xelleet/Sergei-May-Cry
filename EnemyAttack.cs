using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] internal float damage;
    [SerializeField] private float attackRadius;
    [SerializeField] private float moveRadius;

    [SerializeField] protected float currentCoolDown;
    [SerializeField] protected float standartCoolDown;

    [SerializeField] protected List<string> attackAnimations;
     
    protected PlayerHealthManager player;

    public delegate void Attack();
    protected Attack attack;

    [SerializeField] protected float buffDamage;

    private void Awake()
    {
        //SetAttackVoid();

        transform.parent = null;
    }

    private void Start()
    {
        buffDamage = damage;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(moveRadius, 0, moveRadius), Color.green);
        currentCoolDown -= Time.deltaTime;
    }
 
    public void DetectPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRadius && currentCoolDown <= 0)
        {
            if (player.GetComponent<PlayerBlock>().isBlocked)
            {
                StartCoroutine(ChangeDamage(0.5f));
                //Вообще ещё желательно связать кулдаун сверху с анимацией отдачи врага (типа он бьёт, но мы поставили блок и он недалеко отлетает)
            }
            GetComponent<Animator>().Play("Attack");
        }
    }

    public void AttackPlayer()
    {
        attack();
    }

    /*private IEnumerator EnemyStunLock()
    {
        //GetComponent<EnemyAnimation>().SetTriggerAnim("StunLock");
        float buff = GetComponent<NavMeshAgent>().speed;
        GetComponent<EnemyManager>().enabled = false;
        yield return new WaitForSeconds(5f);
        GetComponent<NavMeshAgent>().speed = buff;
        GetComponent<EnemyManager>().enabled = true;
    }*/

    private IEnumerator ChangeDamage(float duration)
    {
        damage = 0f;
        yield return new WaitForSeconds(duration);
        damage = buffDamage;
    }
}
