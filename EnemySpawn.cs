using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] internal List<Transform> enemySpawnPositions;
    [SerializeField] internal List<GameObject> enemyes;

    [SerializeField] private int enemyesAmount;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(gameObject.name) && PlayerPrefs.GetString("Entity") == "Yes") Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemyesAmount == 1)
            {
                Instantiate(enemyes[0], enemySpawnPositions[0]);
                Destroy(gameObject);
                return;
            }

            for (int i = 0; i <= enemyesAmount; i++)
            {
                Instantiate(enemyes[Random.Range(0, enemyes.Count)], enemySpawnPositions[Random.Range(0, enemySpawnPositions.Count)]);
            }
            PlayerPrefs.SetInt(gameObject.name, 1);
            Destroy(gameObject);
        }
    }
}
