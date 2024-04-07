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
    private Queue<string> sentences;//Like a list.

    public Animator animator;
    public float dialogCloseDelay;
    public static bool isActive = false;

    public GameObject continueButton;


    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialog)
    {

        
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;
        sentences.Clear();//清理之前的
        isActive = true;//在播放动画期间,停止player移动
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);//添加新的句子到队列
        }
        
        DisplayNextSentence();

    }
    //continue
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        if (sentences.Count == 1 && continueButton != null)
        {
            continueButton.SetActive(false);
        }
        else if (continueButton != null)
        {
            continueButton.SetActive(true);
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();//如果之前的弹窗未播放完直接
        StartCoroutine(TypeSentence(sentence));//切换到新的弹窗
    }
    //Text In and Out seperately
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(dialogCloseDelay);
        EndDialog();
    }
    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        isActive = false;
        Debug.Log("EndPlz");
    }

}
