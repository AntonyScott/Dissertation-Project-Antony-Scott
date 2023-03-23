using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOverworld : MonoBehaviour
{
    public void LoadNewScene()
    {
        SceneManager.LoadScene("Overworld");
    }
}
