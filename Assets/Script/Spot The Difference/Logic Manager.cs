using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("You won");
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
        Debug.Log("Time up");
    }
}
