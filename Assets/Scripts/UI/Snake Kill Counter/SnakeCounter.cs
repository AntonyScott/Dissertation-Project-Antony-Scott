using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeCounter : MonoBehaviour
{
    private TMP_Text snakeKillCounterText;

    private void Start()
    {
        snakeKillCounterText = GetComponent<TMP_Text>();

        if (PlayerPrefs.HasKey("SnakeKillCount"))
        {
            int snakeKillCount = PlayerPrefs.GetInt("SnakeKillCount");
            Snake.totalSnakeKills = snakeKillCount;
        }
    }

    private void Update()
    {
        if (snakeKillCounterText.text != Snake.totalSnakeKills.ToString())
        {
            snakeKillCounterText.text = Snake.totalSnakeKills.ToString();
        }
    }
}
