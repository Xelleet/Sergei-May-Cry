using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] internal string attackTags;

    private EnemyMovement enemyMovement;
    //private EnemyAttack enemyAttack;
    private EnemyAnimation enemyAnimation;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        //enemyAttack = GetComponent<EnemyAttack>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void FixedUpdate()
    {
        if (enemyMovement != null) enemyMovement.WalkForPlayer();
        if (GetComponent<EnemyAttack>()) GetComponent<EnemyAttack>().DetectPlayer();
    }
}
