using UnityEngine;
using UnityEngine.UI;

public class WeaponInventory : Inventory
{
    private void Awake()
    {
        player = FindObjectOfType<PlayerAttack>();

        LoadWeapon();
    }

    private void LoadWeapon()
    {
        for (int i = 1; i < PlayerPrefs.GetInt("WeaponButtonsCount"); i++)
        {
            Button but = Instantiate(button.GetComponent<Button>(), buttonsTransforms[transformIndex]);
            buttons.Add(but);

            indexes.Add(PlayerPrefs.GetInt("WeaponIndex" + (i - 1)));
            buttons[i].GetComponentInChildren<Text>().text = player.weapons[indexes[i - 1]].name;

            int index = i - 1; //Создаём отдельную переменную потому что делегаты какие-то конченные

            buttons[i].onClick.AddListener(delegate { ChangeWeapon(indexes[index]); });

            transformIndex++;
        }
    }

    public void AddWeaponLote(int index)
    {
        Button but = Instantiate(button.GetComponent<Button>(), buttonsTransforms[transformIndex]);
        buttons.Add(but);

        buttons[transformIndex].onClick.AddListener(delegate { ChangeWeapon(index); });
        buttons[transformIndex].GetComponentInChildren<Text>().text = player.weapons[index].name;

        transformIndex++;
        indexes.Add(index);

        PlayerPrefs.SetInt("WeaponButtonsCount", buttons.Count);

        //На будущее
        //if (FindObjectOfType<GameManager>().difficultMode != "Hard")
        //{
        FindFirstObjectByType<Saving>().Save();
        //{

    }

    public void ChangeWeapon(int index)
    {
        player.currentWeapon.SetActive(false);
        player.currentWeapon = player.weapons[index];
        player.currentWeapon.SetActive(true);
    }
}
