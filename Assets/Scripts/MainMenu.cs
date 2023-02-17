using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Rendering;

public class MainMenu : MonoBehaviour
{
    [Header ("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSliderValue = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Confirmation Prompt")]
    [SerializeField] private GameObject confirmationPrompt;

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

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //show prompt
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSliderValue.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
