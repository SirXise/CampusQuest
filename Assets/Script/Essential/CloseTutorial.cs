using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class CloseTutorial : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    public GameObject Tutorial;

    public void closeTutorial()
    {
        Tutorial.SetActive(false);
        ConversationManager.Instance.StartConversation(myConversation);
    }
}
