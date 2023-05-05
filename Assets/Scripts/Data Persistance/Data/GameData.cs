using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public int coinCounter;

    public GameData()
    {
        this.coinCounter = 0;
    }
}
