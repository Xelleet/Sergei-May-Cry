using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] internal List<Quest> quests;

    //[SerializeField] private GameObject chooseQuestPanel;

    public void SetQuest(int index)
    {
        if (GetComponent<DialogueManager>().currentNodeDialogueIndex == GetComponent<DialogueManager>().dialogues[GetComponent<DialogueManager>().dialogueIndex].dialogues.Count - 1)
        {
            FindObjectOfType<PlayerQuestManager>().quests.Add(quests[index]);
            quests.RemoveAt(index);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //chooseQuestPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //chooseQuestPanel.SetActive(false);
        }
    }
}
