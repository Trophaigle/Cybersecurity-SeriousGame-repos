using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class InteractableObject : MonoBehaviour, IPointerClickHandler
{
    public  ItemType.ItemTypeEnum itemType;
    public bool isDangerous = false;

    public string explanationCorrect = "";
    public string explanationIncorrect = "";

    private bool isAnswered = false;
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData) //pour UI Canvas
    {
        if(GameManager.Instance.isPanelOpen)
            return;
        
        Debug.Log("Object clicked: " + gameObject.name);
        Debug.Log("GameManager instance: " + GameManager.Instance);
        if(isAnswered)
        {
            Debug.LogWarning("Item already answered: " + gameObject.name);
            return;
        }
        GameManager.Instance.SelectItem(this);
    }

    public void ShowResult(bool correct)
    {
        image.color = correct ? Color.green : Color.red;
        SetItemAnswered();
    }

    public void SetItemAnswered()
    {
        if(isAnswered)
        {
            Debug.LogWarning("Item already answered: " + gameObject.name);
            return;
        }
        isAnswered = true;
    }

    public bool IsAnswered()
    {
        return isAnswered;
    }

    public abstract string GetDecisionPanelText(); //implementé dans les classes enfants pour retourner le texte à afficher dans le panneau de décision
}
