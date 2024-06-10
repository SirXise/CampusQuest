using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorial : MonoBehaviour
{
    public GameObject Tutorial;
    public void closeTutorial()
    {
        Tutorial.SetActive(false);
    }
}
