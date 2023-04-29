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

    // Update is called once per frame
    void Awake()
    {
        controls = new MyGameActions();
        controls.UI.Pause.performed += _ => TogglePause();
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

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}

/*private void OnEnable()
    {
        input.Enable();
        input.UI.Pause.performed += OnPausePerformed;
        input.UI.Pause.canceled += OnPauseCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.UI.Pause.performed -= OnPausePerformed;
        input.UI.Pause.canceled -= OnPauseCanceled;
    }

    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Pause Game");
        PauseGame();
    }

    private void OnPauseCanceled(InputAction.CallbackContext context)
    {
        if (GamePaused && pauseMenuUI.activeInHierarchy)
        {
            Debug.Log("Resume Game");
            ResumeGame();
        }
    }*/
