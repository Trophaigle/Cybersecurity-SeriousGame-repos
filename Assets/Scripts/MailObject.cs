using UnityEngine;

public class MailObject : InteractableObject
{

    public string objectMail;
    public string contentMail;

    public override string GetDecisionPanelText()
    {
        return $"<b>Object:</b> {objectMail}\n<b>Content:</b> {contentMail}";
    }

}
