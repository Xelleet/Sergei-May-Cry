using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] internal GameObject weaponInventory;
    [SerializeField] internal GameObject godLikeAbilityInventory;

    internal bool isInInventory;

    private void Update()
    {
        isInInventory = weaponInventory.active || godLikeAbilityInventory.active;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<EnemyAttack>() || collider.GetComponent<Boss>())
            {
                Time.timeScale = isInInventory ? 0.1f : GetComponent<PlayerAttack>().isInFight ? 1.2f : 1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            weaponInventory.SetActive(!weaponInventory.active);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            godLikeAbilityInventory.SetActive(!godLikeAbilityInventory.active);
        }
    }
}
