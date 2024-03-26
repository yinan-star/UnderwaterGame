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
        nameText.text = dialog.name;//�����ָ���textGUI�������ֻ����ʾ��UI�����á���Ϊ��ͬ��Trigger���Ի���һ��������ļ������þ�����������UI�ķ�ʽ��ʾ������ͨ��Trigger���ص���ͬ�������ϡ�
        sentences.Clear();
        sentences.Enqueue(dialog.sentences[0]);//��һ��Element�ͺ��ˡ�
        StartCoroutine(TypeSentence(sentences.Dequeue())); // ֱ�ӿ�ʼ��ʾ����
    }
    
    
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";//������Ϊ��
        foreach (char letter in sentence.ToCharArray())//ToCharArry���ַ���ת���ɵ����ַ���ɵ�����
        {
            dialogueText.text += letter;//����ǰ����ĸһ��һ���ӵ��յ�dialogueText����
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
