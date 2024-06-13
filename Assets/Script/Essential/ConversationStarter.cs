using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{

    [SerializeField] private NPCConversation myConversation;
    public bool playerInRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player in Range");
            ConversationManager.Instance.EndConversation();
        }
    }
}
