using System;
using System.Collections;
using UnityEngine;

public class RuleMessage : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public float displayTime = 3f;
    public float fadeDuration = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ShowAndHide());
    }

   IEnumerator ShowAndHide()
    {
        // Show instantly
        canvasGroup.alpha = 1f;
        gameObject.SetActive(true);

        // Wait
        yield return new WaitForSeconds(displayTime);

        // Fade out
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }

        // Hide completely
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }
}
