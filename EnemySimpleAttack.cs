using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleAttack : EnemyAttack
{
    private void Awake()
    {
        player = FindObjectOfType<PlayerHealthManager>();

        attack = SimpleAttack;
    }

    private void SimpleAttack()
    {
        player.ChangeHealth(damage);
        //GetComponent<EnemyAnimation>().SetTriggerAnim("Attack");
        currentCoolDown = standartCoolDown;
    }
}
