using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Levels to load")]
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField]
    private GameObject noSavedGameDialogueBox = null;

    public void NewGameDialogueYesBtn()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogueYesBtn()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialogueBox.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
