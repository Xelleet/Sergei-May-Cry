using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetTriggerAnim(string animation)
    {
        anim.SetTrigger(animation);
    }

    public void SetAnim(string name)
    {
        anim.SetTrigger(name);
    }
}
