using System.Collections;
using UnityEngine;

public class EnemyStunLockAttack : EnemyAttack
{
    private void Awake()
    {
        player = FindObjectOfType<PlayerHealthManager>();

        attack = StunLockAttack;
    }

    private void StunLockAttack()
    {
        StartCoroutine(StunLock());
    }

    private IEnumerator StunLock()
    {
        player.ChangeHealth(damage);

        //GetComponent<EnemyAnimation>().SetTriggerAnim("Attack");

        currentCoolDown = standartCoolDown;

        player.GetComponent<PlayerManager>().enabled = false;
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerManager>().enabled = true;
    }
}
