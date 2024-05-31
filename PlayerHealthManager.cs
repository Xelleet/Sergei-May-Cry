using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] internal float hp = 100;
    [SerializeField] private Image hpImage;

    [SerializeField] internal List<float> faks;

    [SerializeField] internal Text faksAmount;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HP")) hp = PlayerPrefs.GetFloat("HP");
        if (PlayerPrefs.HasKey("MinHP")) hp = PlayerPrefs.GetFloat("MinHP");

        faks.Clear();

        for (int i = 0; i < PlayerPrefs.GetInt("FAKSCount"); i++)
        {
            faks.Add(PlayerPrefs.GetFloat("FAKS" + i));
        }
    }

    private void FixedUpdate()
    {
        if (hp > 100) hp = 100;
        if (hp < 0)
        {
            GetComponent<PlayerManager>().enabled = false;
            this.enabled = false;

            GetComponent<Animator>().Play("Death");
        }

        hpImage.fillAmount = hp / 100;

        UseFAK();

        faksAmount.text = faks.Count.ToString();
    }

    private void Death()
    {
        PlayerPrefs.DeleteKey("Entity");
        PlayerPrefs.DeleteKey("HP");
        PlayerPrefs.DeleteKey("FAKSCount");

        PlayerPrefs.SetFloat("MinHP", 5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UseFAK()
    {
        if (Input.GetKeyDown(KeyCode.G) && faks.Count > 0 && hp < 100)
        {
            ChangeHealth(-faks[0]);
            faks.RemoveAt(0);
            faksAmount.text = faks.Count.ToString();
            PlayerPrefs.SetInt("FAKSCount", faks.Count);

            for (int i = 0; i < faks.Count; i++)
            {
                PlayerPrefs.SetFloat("FAKS" + i, faks[i]);
            }
        }
    }

    public void ChangeHealth(float amount)
    {
        hp -= amount;
        PlayerPrefs.SetFloat("HP", hp);
    }

    public IEnumerator ChangeHealth(float amount, float duration)
    {
        for (int i = 0; i < duration; i++)
        {
            hp += amount;
            yield return new WaitForSeconds(duration / 4);
        }
    }
}
