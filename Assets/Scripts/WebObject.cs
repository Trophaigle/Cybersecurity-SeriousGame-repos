using UnityEngine;

public class WebObject : InteractableObject
{
    public string url;
    public string contentWeb;

    public override string GetDecisionPanelText()
    {
        return $"<b>URL:</b> {url}\n<b>Content:</b> {contentWeb}";
    }
}
