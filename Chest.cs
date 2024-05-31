using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private float cost;
    [SerializeField] private int weaponIndex;

    [SerializeField] private Text weaponShowText;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(gameObject.name)) Destroy(gameObject);
    }

    public void AddWeapon(GameObject inventory, int index)
    {
        inventory.GetComponent<WeaponInventory>().AddWeaponLote(weaponIndex);
        ShowText(index);
    }

    private void ShowText(int index)
    {
        weaponShowText.gameObject.SetActive(true);
        weaponShowText.text = $"Вы получили {FindObjectOfType<PlayerAttack>().weapons[index].name}!";
        GetComponent<Animator>().Play("Death");
    }

    private void Death()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);
        weaponShowText.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Можно потом ебануть карутину, чтобы можно было всё таки открывать сундук по кнопке
        if (other.CompareTag("Player")/*Input.GetKeyDown(KeyCode.E)*/)
        {
            if (gameObject.CompareTag("ChestWeapon"))
            {
                AddWeapon(FindObjectOfType<WeaponInventory>().gameObject, weaponIndex);
            }
            else if (gameObject.CompareTag("ChestCoins"))
            {
                other.GetComponent<PlayerCurrency>().ChangeCoinsCount(cost);
                PlayerPrefs.SetInt(gameObject.name, 1);
            }
        }
    }
}
