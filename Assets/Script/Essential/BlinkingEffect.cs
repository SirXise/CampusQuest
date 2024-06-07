using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    public float blinkInterval = 0.5f;
    private bool isBlinking = false;
    private Coroutine blinkCoroutine;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("Renderer component not found on the GameObject.");
            return;
        }
        StartBlinking();
    }

    public void StartBlinking()
    {
        if (!isBlinking)
        {
            isBlinking = true;
            blinkCoroutine = StartCoroutine(Blink());
        }
    }

    public void StopBlinking()
    {
        if (isBlinking)
        {
            isBlinking = false;
            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);
                blinkCoroutine = null;
            }
            SetVisibility(true);
        }
    }

    private IEnumerator Blink()
    {
        while (isBlinking)
        {
            SetVisibility(!objectRenderer.enabled);
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void SetVisibility(bool isVisible)
    {
        objectRenderer.enabled = isVisible;
    }
}
