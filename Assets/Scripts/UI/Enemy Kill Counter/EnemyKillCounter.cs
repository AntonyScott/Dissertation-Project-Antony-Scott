using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyKillCounter : MonoBehaviour
{
    public static int snakeKillCount = 0;
    private TMP_Text snakeKillCountText;

    public static int treeEnemyKillCount = 0;
    private TMP_Text treeEnemyKillCountText;

    public static int totalEnemyKills = 0;
    private TMP_Text totalEnemyKillsText;

    private int savedTotalEnemyKills;

    private void Start()
    {
        snakeKillCountText = GetComponent<TMP_Text>();
        treeEnemyKillCountText = transform.GetChild(0).GetComponent<TMP_Text>();
        totalEnemyKillsText = transform.GetChild(1).GetComponent<TMP_Text>();

        // Load the saved enemy kill counts
        if (PlayerPrefs.HasKey("SnakeKillCount"))
        {
            snakeKillCount = PlayerPrefs.GetInt("SnakeKillCount");
        }
        if (PlayerPrefs.HasKey("TreeEnemyKillCount"))
        {
            treeEnemyKillCount = PlayerPrefs.GetInt("TreeEnemyKillCount");
        }
        totalEnemyKills = snakeKillCount + treeEnemyKillCount;

        UpdateUI();
    }

    void UpdateUI()
    {
        snakeKillCountText.text = snakeKillCount.ToString();
        treeEnemyKillCountText.text = treeEnemyKillCount.ToString();
        totalEnemyKillsText.text = totalEnemyKills.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Snake Enemy"))
        {
            snakeKillCount++;
            //totalEnemyKills++;

            Debug.Log("You have killed " + snakeKillCount + " snake enemies.");
        }

        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Tree Enemy"))
        {
            treeEnemyKillCount++;
            //totalEnemyKills++;


            Debug.Log("You have killed " + treeEnemyKillCount + " tree enemies.");
        }
        totalEnemyKills = snakeKillCount + treeEnemyKillCount;
        Debug.Log("Total kills: " + totalEnemyKills);
        UpdateUI();
    }

    void OnApplicationQuit()
    {
        // Save the total enemy kill count
        PlayerPrefs.SetInt("TotalEnemyKills", totalEnemyKills);
        PlayerPrefs.Save();
    }
}
