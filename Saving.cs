using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Saving : MonoBehaviour
{
    [SerializeField] private GameObject saveText;

    [SerializeField] private List<Quest> quests;

    //private int questsIndex = PlayerPrefs.GetInt("QuestIndex");

    private void Awake()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void Save()
    {
        SaveQuest();
        SaveWeaponButtons();
    }

    private void SaveQuest()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            PlayerPrefs.SetString("Quest" + i, JsonUtility.ToJson(quests[i]));

            for (int j = 0; j < quests[i].Targets.Count; j++)
            {
                PlayerPrefs.SetString("Target" + i + j, quests[i].Targets[j].name);
            }
        }
    }

    private void SaveWeaponButtons()
    {
        for (int i = 0; i < FindObjectOfType<WeaponInventory>().indexes.Count; i++)
        {
            PlayerPrefs.SetInt("WeaponIndex" + i, FindObjectOfType<WeaponInventory>().indexes[i]);
        }

        PlayerPrefs.SetInt("ButtonsCount", FindObjectOfType<WeaponInventory>().buttons.Count);
        PlayerPrefs.SetInt("QuestsCount", quests.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            quests = other.GetComponent<PlayerQuestManager>().quests;

            Save();

            PlayerPrefs.SetFloat("x", transform.position.x);
            PlayerPrefs.SetFloat("y", transform.position.y);
            PlayerPrefs.SetFloat("z", transform.position.z);

            StartCoroutine(ActivateSaveText());
        }
    }

    private IEnumerator ActivateSaveText()
    {
        if (saveText == null)
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
            yield break;
        }

        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            saveText.SetActive(false);
            yield break;
        }

        saveText.SetActive(true);
        yield return new WaitForSeconds(2);

        saveText.SetActive(false);
        PlayerPrefs.SetInt(gameObject.name, 1);

        Destroy(gameObject);
    }
}
