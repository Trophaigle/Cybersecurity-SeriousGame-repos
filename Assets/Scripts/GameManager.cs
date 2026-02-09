using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int score;
    
    string[] scenes = {"MailScene", "FileScene"/*, "WebScene"*/};
    public ItemType.ItemTypeEnum[] roundOrder =
    {
        ItemType.ItemTypeEnum.Mail,
        ItemType.ItemTypeEnum.File
      //  ItemType.ItemTypeEnum.Website
    };

    public DecisionPanel decisionPanel;
    public FeedbackPanel feedbackPanel;
    public bool isPanelOpen = false;
    public EndGamePanel endGamePanel;

    public TextMeshProUGUI scoreText;

    private InteractableObject currentItem;
    
    private InteractableObject[] allItem;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctClip;
    public AudioClip incorrectClip;
    public AudioClip endGameClip;

    void Awake() // instance management
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

     void Start()
    {
        allItem = FindObjectsByType<InteractableObject>(FindObjectsSortMode.None);
    }

     public bool AllItemsAnswered()
    {
        return allItem.All(i => i.IsAnswered());
    }

    public void EndGame()
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(endGameClip);
        }
        // Show final score and feedback
        Debug.Log("Game Over! Final Score: " + score);
        endGamePanel.Show("Game Over!\nYour score reflects both accuracy and careful thinking. Avoid clicking too quickly — prudence is key in cybersecurity", score);
    }

    public void SelectItem(InteractableObject item)
    {
        if(item == null)
        {
            Debug.LogError("Selected item is null!");
            return;
        }
       
       currentItem = item;
      /* Debug.Log("ContentText: " + item.contentText);
       if(decisionPanel == null)
       {
           Debug.LogError("DecisionPanel reference is missing in GameManager!");
           return;
       }*/
       decisionPanel.Show(item);
    }

    public void PlayerChoice(bool choseDanger)
    {
        bool correct = choseDanger == currentItem.isDangerous;

      if (correct)
{
    // Good answer → reward
    score += 10;
}
else
{
    // Wrong answer → small penalty
    score -= 3;
}

// Optional: clamp score to not go below 0
score = Mathf.Max(score, 0);

        currentItem.ShowResult(correct);
        
        decisionPanel.Hide();
        DisplayFeedbackPanel(correct);
    }
 
    public bool isGameOver()
    {
        return AllItemsAnswered() && SceneManager.GetActiveScene().buildIndex >= scenes.Length - 1;
    }

    public void ContinueToNext()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
       
        SceneManager.LoadScene(index + 1);
    }

    public void DisplayFeedbackPanel(bool correct)
    {
        //displayfeedback panel for the item
            string feedback = correct
            ? "<color=#00AA00>Correct!</color>\n"
            : "<color=#CC0000>Incorrect!</color>\n";

            if(correct)
                feedback += currentItem.explanationCorrect + "\n";
            else
                feedback += currentItem.explanationIncorrect + "\n";

            feedbackPanel.Show(feedback + "Current score: " + score);

             // Play sound
        if(audioSource != null)
        {
            if(correct && correctClip != null)
                audioSource.PlayOneShot(correctClip);
            else if(!correct && incorrectClip != null)
                audioSource.PlayOneShot(incorrectClip);
        }
    }
}
