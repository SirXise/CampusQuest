using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // Set the time limit here
    public TextMeshProUGUI timerText; // Reference to a TextMeshProUGUI element to display the timer
    public TextMeshProUGUI gameOverText; // Reference to a TextMeshProUGUI element to display the game over message
    public TextMeshProUGUI winText;
    public Button ExitButtonLose;
    public Button ExitButtonWin;
    public Button restart;
    public Image background;
    private float currentTime;
    public static bool isRunning = false;
    
    void Start()
    {
        currentTime = timeLimit;
        StartTimer();
        gameOverText.gameObject.SetActive(false); // Hide the Game Over text at the start
        winText.gameObject.SetActive(false);
        ExitButtonLose.gameObject.SetActive(false);
        ExitButtonWin.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
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
        timerText.text = "Time : " + currentTime.ToString("F2");
    }

    private void GameOver()
    {
        // Show game over message
        gameOverText.gameObject.SetActive(true);
        ExitButtonLose.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        Debug.Log("Game Over!");
        // Optionally, you can add more logic to handle the game over state, such as disabling game inputs
    }
}