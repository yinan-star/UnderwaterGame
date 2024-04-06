using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    public void TriggerDialogue()
    {
        if(dialogue != null)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        
    }

    private void Start()
    {
        TriggerDialogue();

    }
}
