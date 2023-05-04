using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeEnemyCounter : MonoBehaviour
{
    private TMP_Text treeEnemyKillCounterText;

    private void Start()
    {
        treeEnemyKillCounterText = GetComponent<TMP_Text>();

        if (PlayerPrefs.HasKey("TreeEnemyKillCount"))
        {
            int treeEnemyKillCount = PlayerPrefs.GetInt("TreeEnemyKillCount");
            TreeEnemy.totalTreeEnemyKills = treeEnemyKillCount;
        }
    }

    private void Update()
    {
        if (treeEnemyKillCounterText.text != TreeEnemy.totalTreeEnemyKills.ToString())
        {
            treeEnemyKillCounterText.text = TreeEnemy.totalTreeEnemyKills.ToString();
        }
    }
}
