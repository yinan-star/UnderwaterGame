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
    public static bool isActive = false;
 

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialog)
    {
        if (dialog != null)
        {
            isActive = true;
            animator.SetBool("IsOpen", true);
            nameText.text = dialog.name;
            sentences.Clear();
            sentences.Enqueue(dialog.sentences[0]);
            StartCoroutine(TypeSentence(sentences.Dequeue()));
        }
   
    }
    
    
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
    public void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        isActive = false;
        Debug.Log("EndPlz");
    }
   
}
