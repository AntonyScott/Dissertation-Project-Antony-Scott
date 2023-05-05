using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance { get; private set; }
    private GameData gameData;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one data persistence manager is present in the scene");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //load any saved data from file

        //if no data then start new game

        if(this.gameData == null)
        {
            Debug.Log("No data found, loading default data");
            NewGame();
        }

        //send load data to scripts
    }

    public void SaveGame()
    {
        //pass data to other scripts

        //save data to file
    }
}
