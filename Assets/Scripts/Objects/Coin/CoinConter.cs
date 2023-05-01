using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinConter : MonoBehaviour
{
    private TMP_Text coinCounterText;

    private void Start()
    {
        coinCounterText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if(coinCounterText.text != Coin.totalCoins.ToString())
        {
            coinCounterText.text = Coin.totalCoins.ToString();
        }
    }
}
