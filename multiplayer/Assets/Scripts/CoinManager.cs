using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int totalCoins = 0;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        instance = this;
    }

    public void AddCoin(int amount)
    {
        totalCoins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Moedas: " + totalCoins;
    }
}