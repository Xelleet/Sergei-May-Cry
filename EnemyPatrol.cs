using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    [SerializeField] private bool isPatrol;


    [SerializeField] private float speed = 2f;

    [SerializeField] private float dzCoolDown;

    private Vector3 newTarget;

    private NavMeshAgent agent;
    private EnemySpawnDangerZone spawnDangerZone;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        spawnDangerZone = GetComponent<EnemySpawnDangerZone>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        if (isPatrol)
        {
            if (agent.remainingDistance < .25f)
            {
                newTarget = targets[Random.Range(0, targets.Count)].position;
                agent.SetDestination(newTarget);
            }
        }
        else
        {
            StartCoroutine(SpawnDZ());
        }
    }

    private IEnumerator SpawnDZ()
    {
        spawnDangerZone.SpawnDZ();
        yield return new WaitForSeconds(dzCoolDown);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            isPatrol = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            isPatrol = true;
        }
    }
}
