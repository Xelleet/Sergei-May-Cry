using System.Collections;
using UnityEngine;

public class EnemySpawnDangerZone : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float spawnRadius;

    private PlayerManager player;

    [SerializeField] private GameObject dangerZones;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();
    }

    public void SpawnDZ()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= radius)
        {
            Instantiate(dangerZones, new Vector3(Random.Range(transform.position.x, spawnRadius), 0, Random.Range(transform.position.z, spawnRadius)), new Quaternion(0, 0, 0, 0));
        }
    }
}
