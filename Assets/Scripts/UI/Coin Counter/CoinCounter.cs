using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private TMP_Text coinCounterText;

    private void Start()
    {
        coinCounterText = GetComponent<TMP_Text>();

        // Load the saved coin count from player preferences
        if (PlayerPrefs.HasKey("CoinCount"))
        {
            int coinCount = PlayerPrefs.GetInt("CoinCount");
            Coin.totalCoins = coinCount;
        }
    }

    private void Update()
    {
        if(coinCounterText.text != Coin.totalCoins.ToString())
        {
            coinCounterText.text = Coin.totalCoins.ToString();
        }
    }

    private void OnDestroy()
    {
        // Save the coin count when the scene is unloaded
        PlayerPrefs.SetInt("CoinCount", Coin.totalCoins);
    }
}
