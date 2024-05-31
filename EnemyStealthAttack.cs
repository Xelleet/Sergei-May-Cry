using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStealthAttack : EnemyAttack
{
    private void Awake()
    {
        player = FindObjectOfType<PlayerHealthManager>();

        attack = StealthAttack;
    }

    private void StealthAttack()
    {
        GetComponent<EnemyStealth>().UnSetEffect();
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

        player.ChangeHealth(damage);
        currentCoolDown = standartCoolDown;
    }
}
