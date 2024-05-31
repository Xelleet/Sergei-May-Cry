using UnityEngine;
using System;

public class QuestableEnemy : MonoBehaviour
{
    [SerializeField] private string[] questableEnemyNames;

    PlayerQuestManager player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerQuestManager>();
    }

    public void ChangeProgress(float count)
    {
        for (int i = 0; i < player.quests.Count; i++)
        {
            for (int j = 0; j < questableEnemyNames.Length; j++)
            {
                if (player.quests[i].QuestName == questableEnemyNames[j])
                {
                    player.quests[i].CurrentProgess += count;
                }
            }
        }
    }

    //public void ChangeProgressForAllQuests(float count)
    //{
    //    foreach (var item in FindObjectOfType<PlayerQuestManager>().quests)
    //    {
    //        item.CurrentProgess += count;
    //    }
    //}
}
