using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float textSpeed;
    private Queue<string> sentences;

    public Animator animator;
    public float dialogCloseDelay;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialog)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;//将名字给到textGUI，这里的只是显示在UI的作用。因为不同的Trigger，对话不一样，这个文件的作用就是让它们以UI的方式显示出来。通过Trigger挂载到不同的物体上。
        sentences.Clear();
        sentences.Enqueue(dialog.sentences[0]);//拿一个Element就好了。
        StartCoroutine(TypeSentence(sentences.Dequeue())); // 直接开始显示句子
    }
    
    
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";//假设先为空
        foreach (char letter in sentence.ToCharArray())//ToCharArry将字符串转换成单个字符组成的数组
        {
            dialogueText.text += letter;//将当前的字母一个一个加到空的dialogueText里面
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(dialogCloseDelay);
        EndDialog();
    }
    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("EndPlz");
    }
}
