using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkingEffect : MonoBehaviour
{
    public float blinkInterval = 0.5f;
    private bool isBlinking = false;
    private Coroutine blinkCoroutine;
    private Renderer objectRenderer;
    private TMP_Text textMeshPro;

    void Start()
    {
        if (TryGetComponent<Renderer>(out objectRenderer))
        {
            // Renderer component found
            StartBlinking();
        }
        else if (TryGetComponent<TMP_Text>(out textMeshPro))
        {
            // TMP_Text component found
            StartBlinking();
        }
        else
        {
            Debug.LogError("Neither Renderer nor TMP_Text component found on the GameObject.");
        }
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
            if (objectRenderer != null)
            {
                SetVisibility(!objectRenderer.enabled);
            }
            else if (textMeshPro != null)
            {
                SetVisibility(!textMeshPro.enabled);
            }
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void SetVisibility(bool isVisible)
    {
        if (objectRenderer != null)
        {
            objectRenderer.enabled = isVisible;
        }
        else if (textMeshPro != null)
        {
            textMeshPro.enabled = isVisible;
        }
    }
}
