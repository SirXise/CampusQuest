using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // Set the time limit here
    public Text timerText; // Reference to a UI Text element to display the timer
    public Text gameOverText; // Reference to a UI Text element to display the game over message
    private float currentTime;
    private bool isRunning = false;

    void Start()
    {
        currentTime = timeLimit;
        StartTimer();
        gameOverText.gameObject.SetActive(false); // Hide the Game Over text at the start
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
                GameOver();
            }
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + currentTime.ToString("F2");
    }

    private void GameOver()
    {
        // Show game over message
        gameOverText.gameObject.SetActive(true);
        Debug.Log("Game Over!");
        // Optionally, you can add more logic to handle the game over state, such as disabling game inputs
    }
}