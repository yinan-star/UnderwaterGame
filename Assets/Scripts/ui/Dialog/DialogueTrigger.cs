using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public Sentence[] sentences;
    public NameText nameText; 
    
    
    //public void TriggerDialogue()
    //{
    //    FindObjectOfType<DialogueManager>().StartCoroutine(); ;
    //}
    [System.Serializable]
    public class Sentence//单个的句子
    {
        [TextArea(3, 10)]
        public string sentence;
        
    }
    [System.Serializable]
    public class NameText
    {
        public string nameText;
    }

}
