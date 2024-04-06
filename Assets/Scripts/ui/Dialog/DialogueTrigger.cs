using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool playerIsClose = false;

    private void Update()
    {
        if (playerIsClose)//????ArchPonit
        {
            TiggerDialogue();
        }
    }

    public void TiggerDialogue()
    {
        if(dialogue != null)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);//??DialogueManager??????????
        }
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)//????ArchPoint,???,???.
    {
        if (other.CompareTag("ArchPoint"))
        {      
            playerIsClose = true;
            Debug.Log("FindArchPoint,IsClose");
        }
        else
        {
            Debug.Log("Can'tFindTag");
        }
    }
    private void OnTriggerExit2D(Collider2D other)//????ArchPoint,???,???.
    {
        if (other.CompareTag("ArchPoint"))
        {
            playerIsClose = false;
            Debug.Log("FindArchPoint,NotCloseYet");
        }
        else
        {
            Debug.Log("Can'tFindTag");
        }

    }

    private void Start()
    {
        TiggerDialogue();
    }
}
