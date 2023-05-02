using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //array of sounds (mp3's etc)
    public static AudioManager instance;

    private bool isFadingOut = false;

    // Start is called before the first frame update
    void Awake()
    {
        //destroys any other instance of audiomanager which may be present in other scenes
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); //makes sure the audiomanager is not destroyed when transitioning between scenes

        foreach (Sound s in sounds)
        {
            //assigns audiosource, audioclip, volume, pitch and loop functions for each sound in the array
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //starts playing sound
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        if (s.source.isPlaying)
        {
            s.source.UnPause();
        }
        else
        {
            s.source.Play();
        }
    }

    //stops playing sound
    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound + " not found!");
            return;
        }

        s.source.Stop();
    }

    //pause function (used when activating pause menu)
    public void PauseAll()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.Pause();
            }
        }
    }

    //resume function (used when de-activating pause menu)
    public void ResumeAll()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying == false)
            {
                s.source.UnPause();
            }
        }
    }

    void Update()
    {
        MusicSceneTransitions();
    }

    //transitions background music between dungeon and overworld scenes
    void MusicSceneTransitions()
    {
        //Debug.Log("Audio manager update method called!");
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName.StartsWith("Dungeon"))
        {
            StopPlaying("Main Menu Theme");
            Play("Dungeon Theme");
        }
        else if (sceneName == "Main Menu" || sceneName == "Overworld" || sceneName == "Credits")
        {
            StopPlaying("Dungeon Theme");
            Play("Main Menu Theme");
        }
    }

}
