using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public GameObject marker;
    public GameObject differences;
    public Text scoreText;
    private int counter;
    private int ObjectCount;
    public bool isWon = false;
    public TextMeshProUGUI WinLoseText;
    public Button ExitButtonWin, ExitButtonLose, RestartButton;

    private void Start()
    {
        ObjectCount = differences.transform.childCount;
    }
    public void clickDetected()
    {
        if(!isWon)
        {
            counter += 1;
            ObjectCount -= 1;
            checkGameDone();
            scoreText.text = counter.ToString();
        }
    }

    public void spawnMarker(Vector3 position, Quaternion rotation)
    {
        Instantiate(marker, position, rotation);
    }

    private void checkGameDone()
    {
        if (ObjectCount == 0)
        {
            isWon = true;
            WinLoseText.text = "You won!";
            ExitButtonWin.gameObject.SetActive(true);
        }
    }

    public void loseGame()
    {
        // Disable all BoxCollider2D components in the children of differences
        BoxCollider2D[] colliders = differences.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D collider in colliders)
        {
            collider.enabled = false;
        }
        WinLoseText.color = Color.red;
        WinLoseText.text = "Game Over!";
        ExitButtonLose.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }
}
