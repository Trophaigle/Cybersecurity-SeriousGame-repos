using TMPro;
using UnityEngine;

public class DecisionPanel : MonoBehaviour
{
    public TextMeshProUGUI contentText;

    public void Show(InteractableObject item)
    {
        gameObject.SetActive(true);
        gameObject.transform.SetAsLastSibling(); // Ensure the panel is on top
        GameManager.Instance.isPanelOpen = true; // Indicate that the panel is open

        // Formattage avec style
        contentText.text = item.GetDecisionPanelText();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        GameManager.Instance.isPanelOpen = false; // Indicate that the panel is closed
    }

    public void OnSafeClicked()
    {
        Debug.Log("Safe button clicked");
        GameManager.Instance.PlayerChoice(false);
      
    }

    public void OnDangerClicked()
    {
        Debug.Log("Danger button clicked");
        GameManager.Instance.PlayerChoice(true);
       
    }
}
