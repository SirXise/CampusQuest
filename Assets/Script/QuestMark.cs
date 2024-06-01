using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMark : MonoBehaviour
{
    public GameObject questMark;

    public void Enable()
    {
        questMark.SetActive(true);
    }

    public void Disable()
    {
        questMark.SetActive(false);
    }
}
