using UnityEngine;

public class EnemyStealth : MonoBehaviour
{
    [SerializeField] private GameObject stealthEffect;

    internal void UnSetEffect()
    {
        stealthEffect.SetActive(false);
    }
}
