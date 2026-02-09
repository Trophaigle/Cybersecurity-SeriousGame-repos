using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GlowUnanswered : MonoBehaviour
{
    public Outline outline; // or Image border
    public float glowDuration = 1f; // one pulse time
    public bool isAnswered = false;

    private void OnEnable()
    {
        if (!isAnswered)
            StartCoroutine(GlowCoroutine());
    }

    public void MarkAnswered()
    {
        isAnswered = true;
        if (outline != null) outline.enabled = false; // stop glow
    }

   private IEnumerator GlowCoroutine()
    {
        while (!isAnswered)
        {
            // fade in
            float t = 0f;
            while (t < glowDuration)
            {
                t += Time.deltaTime;
                float alpha = Mathf.PingPong(t * 2f, 1f); // 0 → 1 → 0
                outline.effectColor = new Color(1f, 0.9f, 0f, alpha); // yellow glow
                yield return null;
            }
        }
        outline.enabled = false;
    }
}
