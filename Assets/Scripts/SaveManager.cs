using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManager
{
    public static void SaveGame(GameState gameState)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/save.dat";
        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        formatter.Serialize(fileStream, gameState);
        fileStream.Close();
    }

    public static GameState LoadGame()
    {
        string savePath = Application.persistentDataPath + "/save.dat";
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Open);
            GameState gameState = (GameState)formatter.Deserialize(fileStream);
            fileStream.Close();
            return gameState;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }

    [System.Serializable]
    public class GameState
    {
        public string currentRoom = PlayerPrefs.GetString("LevelSaved");
        //public Vector2 playerPosition;
        public int coinsCollected;
        public int snakeKillCount;
        public int treeEnemyKillCount;
        public int totalEnemiesKilled;
    }
}
