using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private MyGameActions controls;
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    public bool loadMenuCalled = false;

    // Update is called once per frame
    void Awake()
    {
        controls = new MyGameActions();
        controls.UI.Pause.performed += _ => TogglePause();
        //DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        controls.UI.Enable();
    }

    void OnDisable()
    {
        controls.UI.Disable();
    }

    void TogglePause()
    {
        if (GamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().ResumeAll();
        GamePaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        FindObjectOfType<AudioManager>().PauseAll();
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Load menu");
        Time.timeScale = 1f;

        // Find the canvas object and destroy it
        GameObject canvasObject = GameObject.FindGameObjectWithTag("UI");
        if (canvasObject != null)
        {
            Destroy(canvasObject);
        }

        // Find the player object and destroy it
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Destroy(playerObject);
        }

        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LevelSaved", activeScene);

        // Load the Main Menu scene
        SceneManager.LoadScene("Main Menu");

        // Set the loadMenuCalled variable to true
        loadMenuCalled = true;

        // Destroy the Pause Menu object
        Destroy(gameObject);
    }

    public bool GetLoadMenuCalled()
    {
        return loadMenuCalled;
    }

    public void QuitGame()
    {
        Debug.Log("Quit game!");
        Application.Quit();
    }
}
