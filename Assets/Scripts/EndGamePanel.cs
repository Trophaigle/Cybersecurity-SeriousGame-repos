using System.Collections;
using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    public TextMeshProUGUI text;       // Assign your TMP text
    public CanvasGroup canvasGroup;     // Assign the CanvasGroup
    public float fadeDuration = 0.5f;   // Fade-in duration in seconds
   private void Awake()
    {
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    public void Show(string endGameText, int score)
    {
        // Make the panel visible
        gameObject.SetActive(true);
        gameObject.transform.SetAsLastSibling();

        // Set the text
        text.text = endGameText + "\n\nYour final score: " + score;

        // Start fade-in
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }

        // Ensure fully visible at the end
        canvasGroup.alpha = 1f;

        // DO NOT deactivate — panel stays on screen
    }
}
