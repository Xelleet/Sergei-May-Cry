using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelManager : MonoBehaviour
{
    [SerializeField] internal float level;
    [SerializeField] internal float intelligence;
    [SerializeField] internal float agility;

    [SerializeField] internal float levelScore = 0;

    [SerializeField] private float improvementCount = 0;

    [SerializeField] private Image levelImage;
    [SerializeField] private Image intelligenceImage;
    [SerializeField] private Image agilityImage;

    [SerializeField] private List<Button> buttons;
    private AudioClip audio;

    [SerializeField] private Text levelScoreText;
    [SerializeField] private Text improvementCountText;

    [SerializeField] private GameObject statsPanel;
    [SerializeField] private GameObject mainCanvas;

    [SerializeField] private float levelDivider;
    [SerializeField] private float intelligenceDivider;
    [SerializeField] private float agilityDivider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenStatsPanel();
        }

        SetFillAmount();

        if (level >= levelDivider)
        {
            SetNewLevelScore();
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<EnemyAttack>() || collider.GetComponent<Boss>())
            {
                //Time.timeScale = statsPanel.active ? 0.1f : GetComponent<PlayerAttack>().isInFight ? 1.2f : 1f;
            }
        }
    }

    public void ChangeStat(string stat, float count)
    {
        switch (stat)
        {
            case "Level":
                level += count;
                break;
            case "Intelligence":
                intelligence += count;
                break;
            case "Agility":
                agility += count;
                break;
        }
    }

    /*public void ChangeStat(int index)
    {
        switch (index)
        {
            case 0:
                level += index;
                break;
            case 1:
                intelligence += indexes[1];
                break;
            case 2:
                agility += indexes[1];
                break;
        }


        if (improvementCount == 0)
        {
            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }*/

    private void SetFillAmount()
    {
        levelImage.fillAmount = level / levelDivider;
        intelligenceImage.fillAmount = intelligence / intelligenceDivider;
        agilityImage.fillAmount = agility / agilityDivider;
    }

    private void OpenStatsPanel()
    {
        statsPanel.SetActive(!statsPanel.active);
        mainCanvas.SetActive(!mainCanvas.active);
    }

    private void SetNewLevelScore()
    {
        level = 0;

        levelScore++;
        improvementCount++;

        levelScoreText.text = levelScore.ToString();
        improvementCountText.text = improvementCount.ToString();

        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    private void Save()
    {
        //Это на будущее
        PlayerPrefs.SetFloat("Level", level);
    }
}