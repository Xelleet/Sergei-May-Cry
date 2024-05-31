using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    [SerializeField] internal float coins = 0f;

    [SerializeField] private Text coinsText;

    private void Awake()
    {
        coins = PlayerPrefs.GetFloat("CoinsAmount");
        coinsText.text = coins.ToString();
    }

    private void FixedUpdate()
    {
        coinsText.text = coins.ToString();
    }

    public void ChangeCoinsCount(float count)
    {
        coins += count;
        PlayerPrefs.SetFloat("CoinsAmount", coins);
    }
}
