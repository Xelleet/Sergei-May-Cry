using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] internal List<DialogueNode> dialogues;

    [SerializeField] internal GameObject dialoguePanel;

    [SerializeField] private GameObject mainCanvas;

    [SerializeField] private Text dialogueText;
    [SerializeField] private Image personImage;

    [SerializeField] internal int dialogueIndex = 0;
    [SerializeField] internal int currentNodeDialogueIndex = 0;

    private PlayerManager player;

    private void Awake()
    {
        mainCanvas = GameObject.Find("MainCanvas");

        player = FindObjectOfType<PlayerManager>();
    }

    public void ShowDialogue()
    {
        currentNodeDialogueIndex++;

        if (currentNodeDialogueIndex >= dialogues[dialogueIndex].dialogues.Count)
        {
            StopDialogue();
            return;
        }

        if (dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].Chooses.Count > 0)
        {
            dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].ChoosePanel.SetActive(true);
            dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].ChoosePanel.GetComponent<ChoosePanel>();
        }

        //Вообще-то нам бы щас реализовать систему выбора
        if (dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].Quests != null)
        {
            foreach (Quest quest in dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].Quests)
            {
                FindObjectOfType<PlayerQuestManager>().SetTarget(quest);
            }
        }

        dialogueText.text = dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].DialogueText;
        personImage.sprite = dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].PersonImage;
        player.dialogueAudio.clip = dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].Audio;
        player.dialogueAudio.Play();
    }

    public void BackUpDialogue()
    {
        if (currentNodeDialogueIndex - 2 >= 0) currentNodeDialogueIndex -= 2;
        ShowDialogue();
    }

    private void StopDialogue()
    {
        dialoguePanel.SetActive(false);
        mainCanvas.SetActive(true);
        currentNodeDialogueIndex = 0;
        dialogueIndex++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && dialogues != null)
        {
            if (dialogueIndex == dialogues.Count) return;

            dialogueText.text = dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].DialogueText;
            personImage.sprite = dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].PersonImage;
            dialoguePanel.SetActive(true);
            mainCanvas.SetActive(false);

            player.dialogueAudio.clip = dialogues[dialogueIndex].dialogues[currentNodeDialogueIndex].Audio;
            player.dialogueAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            mainCanvas.SetActive(true);
        }
    }
}

[Serializable]
public class Dialogue
{
    public int DialogueIndex;
    public string DialogueText;
    public AudioClip Audio;
    public Sprite PersonImage;
    public bool IsEnabled = true;
    public List<Choose> Chooses;
    public GameObject ChoosePanel;
    public List<Quest> Quests;
}

[Serializable]
public class DialogueNode
{
    public List<Dialogue> dialogues;
}

[Serializable]
public class Choose
{
    public string FirstChoose;
    public string SecondChoose;
    public int FirstChooseIndex;
    public int SecondChooseIndex;
}