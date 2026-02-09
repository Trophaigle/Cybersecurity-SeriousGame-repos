using UnityEngine;

public class FileObject : InteractableObject
{
   public string fileName;
    public string contentFile;

    public override string GetDecisionPanelText()
    {
        return $"<b>File Name:</b> {fileName}\n<b>Content:</b> {contentFile}";
    }
}
