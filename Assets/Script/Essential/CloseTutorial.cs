using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CloseTutorial : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    public GameObject Tutorial;

    int storeData = 0;

    string dataStoreName = "TutorialCanvas";

    private void Awake()
    {
        storeData = PlayerPrefs.GetInt(dataStoreName,0);
        Tutorial.SetActive(storeData == 0);
        PlayerPrefs.SetInt(dataStoreName,1);
    }

    public void closeTutorial()
    {
        Tutorial.SetActive(false);
        ConversationManager.Instance.StartConversation(myConversation);
    }
}
