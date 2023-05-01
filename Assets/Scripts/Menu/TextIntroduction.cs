using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class TextIntroduction : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public float firstTextBoxDuration = 5.0f;
    public float delayBetweenTransitions = 5.0f;

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(FadeInSequence());
    }

    private void Update()
    {
        // Check if the space bar has been pressed to skip to the next scene
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Load the next scene
            SceneManager.LoadScene("Overworld");
        }
    }

    private IEnumerator FadeInSequence()
    {
        // Handle the first text box separately
        if (currentIndex < texts.Length)
        {
            TextMeshProUGUI currentText = texts[currentIndex];
            yield return FadeText(currentText, 0f, 1f, fadeInDuration);
            yield return new WaitForSeconds(firstTextBoxDuration);
            yield return FadeText(currentText, 1f, 0f, fadeOutDuration);
            currentIndex++;
        }

        while (currentIndex < texts.Length)
        {
            TextMeshProUGUI currentText = texts[currentIndex];
            yield return FadeText(currentText, 0f, 1f, fadeInDuration);

            // Wait for a set amount of time or until the space bar is pressed
            float timer = 0f;
            while (timer < delayBetweenTransitions)
            {
                if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.clickCount.IsPressed())
                {
                    // Load the next scene
                    SceneManager.LoadScene("Overworld");
                }

                timer += Time.deltaTime;
                yield return null;
            }

            yield return FadeText(currentText, 1f, 0f, fadeOutDuration);
            currentIndex++;
        }

        // Load the next scene when all texts have been displayed
        SceneManager.LoadScene("Overworld");
    }

    private IEnumerator FadeText(TextMeshProUGUI text, float startAlpha, float endAlpha, float duration)
    {
        float startTime = Time.time;
        Color startColor = text.color;
        startColor.a = startAlpha;
        text.color = startColor;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            Color currentColor = text.color;
            currentColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            text.color = currentColor;
            yield return null;
        }

        Color endColor = text.color;
        endColor.a = endAlpha;
        text.color = endColor;
    }
}
