using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] internal float damage;
    [SerializeField] internal float attackRadius;
    [SerializeField] internal float standartCoolDown;
    [SerializeField] internal float currentCoolDown;

    [SerializeField] internal string tag;
}
