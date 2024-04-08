using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public Sentence[] sentences;//对象上的句子组
    public string nameText;
    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(sentences, nameText);//把当前存的给Trigger
    }


}
[System.Serializable]
public class Sentence//�����ľ���
{
    [TextArea(3, 10)]
    public string sentence;

}

