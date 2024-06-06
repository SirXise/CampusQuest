using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    MainToken[] visibleFaces = new MainToken[2];
    private Timer timer;
    private int matchesFound = 0;

    void Start()
    {
        int originalLength = faceIndexes.Count;
        float yPosition = 2.3f;
        float xPosition = -2.2f;
        for (int i = 0; i < 7; i++)
        {
            shuffleNum = rnd.Next(0, (faceIndexes.Count));
            var temp = Instantiate(token, new Vector3(
                xPosition, yPosition, 0),
                Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            xPosition = xPosition + 4;
            if (i == (originalLength / 2 - 2))
            {
                yPosition = -2.3f;
                xPosition = -6.2f;
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceIndexes[0];

        // Initialize timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
    }

    public bool TwoCardsUp()
    {
        return visibleFaces[0] != null && visibleFaces[1] != null;
    }

    public void AddVisibleFace(MainToken token)
    {
        if (visibleFaces[0] == null)
        {
            visibleFaces[0] = token;
        }
        else if (visibleFaces[1] == null)
        {
            visibleFaces[1] = token;
        }

        if (TwoCardsUp())
        {
            if (visibleFaces[0].faceIndex == visibleFaces[1].faceIndex)
            {
                visibleFaces[0].SetMatched();
                visibleFaces[1].SetMatched();
                ClearVisibleFaces();
                matchesFound++;
                CheckWinCondition();
            }
            else
            {
                StartCoroutine(ResetVisibleFaces());
            }
        }
    }

    public void RemoveVisibleFace(MainToken token)
    {
        if (visibleFaces[0] == token)
        {
            visibleFaces[0] = null;
        }
        else if (visibleFaces[1] == token)
        {
            visibleFaces[1] = null;
        }
    }

    public void ClearVisibleFaces()
    {
        visibleFaces[0] = null;
        visibleFaces[1] = null;
    }

    private IEnumerator ResetVisibleFaces()
    {
        yield return new WaitForSeconds(1);

        foreach (var token in visibleFaces)
        {
            if (token != null)
            {
                token.GetComponent<SpriteRenderer>().sprite = token.back;
            }
        }
        ClearVisibleFaces();
    }

    private void CheckWinCondition()
    {
        if (matchesFound >= 4) // Assuming there are 4 pairs to match
        {
            timer.StopTimer();
            Debug.Log("You Win!");
            // Show win message or perform any win actions
        }
    }

    private void Awake()
    {
        token = GameObject.Find("Token");
    }

    
}