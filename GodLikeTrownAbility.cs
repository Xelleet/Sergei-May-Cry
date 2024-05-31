using UnityEngine;

public class GodLikeTrownAbility : MonoBehaviour
{
    [SerializeField] internal float damage;

    [SerializeField] private float speed;

    private Rigidbody rb;

    private void Awake()
    {
        gameObject.transform.parent = null;

        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>())
        {
            Debug.Log(123);
            other.GetComponent<Entity>().ChangeHealth(damage);
            Destroy(gameObject);
        }
    }
}
