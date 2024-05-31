using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float radius = 10f;

    private PlayerManager player;

    private NavMeshAgent agent;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    public void WalkForPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            GetComponent<EnemyAnimation>().SetAnim("Walk");
            agent.SetDestination(player.transform.position);
        }
    }
}
