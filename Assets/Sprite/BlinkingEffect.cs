using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    public float blinkInterval = 0.5f;  // Time interval between blinks in seconds
    private bool isBlinking = false;    // Control the blinking state

    // Start is called before the first frame update
    void Start()
    {
        StartBlinking();
    }

    public void StartBlinking()
    {
        if (!isBlinking)
        {
            isBlinking = true;
            StartCoroutine(Blink());
        }
    }

    public void StopBlinking()
    {
        if (isBlinking)
        {
            isBlinking = false;
            StopCoroutine(Blink());
            SetVisibility(true);
        }
    }

    private IEnumerator Blink()
    {
        while (isBlinking)
        {
            SetVisibility(!gameObject.activeSelf);
            // Wait for the specified interval
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void SetVisibility(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }
}
