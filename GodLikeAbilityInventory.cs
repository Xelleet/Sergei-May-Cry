using UnityEngine;
using UnityEngine.UI;

public class GodLikeAbilityInventory : Inventory
{
    private void Awake()
    {
        player = FindObjectOfType<PlayerAttack>();
    }

    private void LoadGodLikeAbility()
    {
        for (int i = 1; i < PlayerPrefs.GetInt("GodLikeAbilityButtonsCount"); i++)
        {
            Button but = Instantiate(button.GetComponent<Button>(), buttonsTransforms[transformIndex]);
            buttons.Add(but);

            indexes.Add(PlayerPrefs.GetInt("GodLikeAbilityIndex" + (i - 1)));
            buttons[i].GetComponentInChildren<Text>().text = player.weapons[indexes[i - 1]].name;

            int index = i - 1; //Создаём отдельную переменную потому что делегаты какие-то конченные

            buttons[i].onClick.AddListener(delegate { ChangeGodLikeAbilty(indexes[index]); });

            transformIndex++;
        }
        transformIndex = 1;
    }

    public void AddGodLikeAbilityLote(int index)
    {
        Button but = Instantiate(button.GetComponent<Button>(), buttonsTransforms[transformIndex]);
        buttons.Add(but);

        buttons[transformIndex].onClick.AddListener(delegate { ChangeGodLikeAbilty(index); });
        buttons[transformIndex].GetComponentInChildren<Text>().text = player.weapons[index].name;

        transformIndex++;
        indexes.Add(index);

        PlayerPrefs.SetInt("GodLikeAbilityButtonsCount", buttons.Count);

        //На будущее
        //if (FindObjectOfType<GameManager>().difficultMode != "Hard")
        //{
        FindFirstObjectByType<Saving>().Save();
        //{

    }

    public void ChangeGodLikeAbilty(int index)
    {
        player.currentGodLikeAbilites = player.godLikeAbilites[index];
        player.currentGodLikeAbilitiesIndex = index;
    }
}
