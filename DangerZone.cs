using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private float lifeCount; //💀
    [SerializeField] internal float damage;

    private void Update()
    {
        lifeCount -= Time.deltaTime;

        if (lifeCount <=0)
        {
            Destroy(gameObject);
        }
    }
}
