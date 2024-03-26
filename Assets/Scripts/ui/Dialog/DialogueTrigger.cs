using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //public void TiggerDialogue()
    //{
    //    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);//找DialogueManager去触发对话
    //}
    private void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);//找DialogueManager去触发对话
    }
}
