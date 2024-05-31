using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerQuestManager : MonoBehaviour
{
    //[SerializeField] internal List<KillQuest> killQuest;
    //[SerializeField] internal List<FindQuest> findQuests;

    [SerializeField] internal List<Quest> quests;

    private void Awake()
    {
        LoadQuests();
    }

    private void LoadQuests()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("QuestsCount"); i++)
        {
            quests.Add(JsonUtility.FromJson<Quest>(PlayerPrefs.GetString("Quest" + i)));
            for (int j = 0; j < quests[i].Targets.Count; j++)
            {
                GameObject target = GameObject.Find(PlayerPrefs.GetString("Target" + i + j));
                if (target != null) quests[i].Targets.Add(target);
            }
        }
    }

    private void FixedUpdate()
    {
        CheckProgress();
    }

    public void SetTarget(Quest quest)
    {
        quests.Add(quest);
        //FindObjectOfType<QuestsPanel>().SetText(quests[0].QuestText);
        //Debug.Log(quests[0].QuestText);
    }

    public void CheckProgress()
    {
        foreach (var item in quests.ToList())
        {
            if (item.CurrentProgess >= item.RequiredProgress)
            {
                item.IsActive = false;
                GetComponent<PlayerCurrency>().coins += item.Currency;
                quests.Remove(item);    
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<QuestableEnemy>())
        {
            other.GetComponent<QuestableEnemy>().ChangeProgress(1);
        }
    }
}
