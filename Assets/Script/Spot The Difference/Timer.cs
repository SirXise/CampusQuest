using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public LogicManager logic;
    public Text timerText;
    private bool timesUp = false;
    
    // Update is called once per frame
    void Update()
    {
        if (!timesUp && !logic.isWon)
        {
            timeLeft -= Time.deltaTime;
            int displayTime = Mathf.CeilToInt(timeLeft);
            timerText.text = displayTime.ToString();
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                gameOver();
            }
        }
    }

    private void gameOver()
    {
        timesUp = true;
        logic.loseGame();
    }
}
