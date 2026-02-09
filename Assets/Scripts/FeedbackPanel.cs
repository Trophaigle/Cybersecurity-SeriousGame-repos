using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackPanel : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;
    public string endRoundText;

    [Header("Audio")]
    public AudioClip correctClip;
    public AudioClip incorrectClip;

    public void Show(string explanation)
    {
        
        gameObject.SetActive(true);
        gameObject.transform.SetAsLastSibling();
        GameManager.Instance.isPanelOpen = true;
        
        feedbackText.text = explanation;
    }

   public void OnContinue()
{
    gameObject.SetActive(false);
    GameManager.Instance.isPanelOpen = false; // Indicate that the panel is closed
    if(GameManager.Instance.isGameOver())
    {
        GameManager.Instance.EndGame();
        return;
    }

    if (GameManager.Instance.AllItemsAnswered())
    {
        Show("Round completed! Your score: " + GameManager.score + "\n" + endRoundText + "\n\nContinuing to next round...");
        gameObject.transform.GetChild(1).gameObject.SetActive(false); // hide continue button
        StartCoroutine(WaitAndContinue(5f)); // attend 5 secondes
    }
}

private IEnumerator WaitAndContinue(float seconds)
{
    yield return new WaitForSeconds(seconds); // attend X secondes
    GameManager.Instance.ContinueToNext();
}
}
