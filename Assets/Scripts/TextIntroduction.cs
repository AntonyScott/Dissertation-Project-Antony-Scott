using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextIntroduction : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public float delayBetweenTransitions = 5.0f;

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(FadeInSequence());
    }

    private IEnumerator FadeInSequence()
    {
        while (currentIndex < texts.Length)
        {
            TextMeshProUGUI currentText = texts[currentIndex];
            yield return FadeText(currentText, 0f, 1f, fadeInDuration);
            yield return new WaitForSeconds(delayBetweenTransitions);
            yield return FadeText(currentText, 1f, 0f, fadeOutDuration);
            currentIndex++;
        }
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
