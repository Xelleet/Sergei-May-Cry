using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    [SerializeField] internal float hp = 100f;

    [SerializeField] private float coinsReward = 0f;
    [SerializeField] private float levelReward = 0f;

    private Animator anim;

    private void Awake()
    {
        if (GetComponentInParent<Transform>()) transform.parent = null;

        if (PlayerPrefs.GetInt(gameObject.name) == 1 && PlayerPrefs.GetString("Entity") == "Yes") Destroy(gameObject);

        anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        if (hp <= 0)
        {
            //“ут надо покумекать и сделать так, чтобы двести п€тьсот строчек не писать
            if (GetComponent<QuestableEnemy>() != null) GetComponent<QuestableEnemy>().ChangeProgress(1);
            if (GetComponent<NavMeshAgent>() != null) GetComponent<NavMeshAgent>().speed = 0;
            if (GetComponent<StandartBoss>() != null) GetComponent<StandartBoss>().enabled = false;
            if (GetComponent<EnemyAttack>() != null) GetComponent<EnemyAttack>().enabled = false;
            if (anim != null) anim.Play("Death");
        }
    }

    private void Death()
    {
        PlayerPrefs.SetInt(gameObject.name, GetComponent<EnemyAttack>() ? 0 : 1);
        PlayerPrefs.SetString("Entity", "Yes");

        FindObjectOfType<PlayerLevelManager>().ChangeStat("Level", levelReward);

        Destroy(gameObject);
    }

    private void GiveRewardToPlayer()
    {
        FindObjectOfType<PlayerCurrency>().ChangeCoinsCount(coinsReward);
    }

    private void RemoveDialoguePanel()
    {
        // остыли, костыли костыли
        if (GetComponent<DialogueManager>()) GetComponent<DialogueManager>().dialogueIndex = GetComponent<DialogueManager>().dialogues.Count;
    }

    public void ChangeHealth(float count)
    {
        hp -= count;
    }

    public IEnumerator ChangeHealth(float count, float duration)
    {
        for (int i = 0; i < duration; i++)
        {
            hp -= count;
            yield return new WaitForSeconds(duration / 4);
        }
    }
}
