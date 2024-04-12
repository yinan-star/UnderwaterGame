using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;//显示文字
    public TextMeshProUGUI nameText;//显示名字

    private int activeSentence = 0;//当前激活的句子为0
    public float typingSpeed;

    Sentence[] currentSentences;//存当前的句子组
    string currentNameText; //存当前的名字

    public static bool isActive = false;

    public GameObject continueButton;
    public Animator animator;

    //另一个中间弹窗的动画
    private AnimMiddleDialogueManager animMiddleDialogueManager;


    void Start()
    {
        animator.SetBool("IsOpen", true);
    }

    void Update()
    {
        //更新句子
        if (Input.GetKeyDown(KeyCode.X) && isActive == true)
        {
            NextSentence();
        }
        //更新继续按钮
        if (activeSentence < currentSentences.Length && textDisplay.text == currentSentences[activeSentence].sentence)
        {
            continueButton.SetActive(true);
        }
    }

    //把当前对象身上挂的Trigger的info传进来
    public void OpenDialogue(Sentence[] sentences, string nameText)
    {
        currentSentences = sentences;
        currentNameText = nameText;
        activeSentence = 0;
        isActive = true;
        DisplaySentence();

        if (Spawn.isTageWithEnding)//如果是是带有ending的标签.就播放这个Middle动画
        {
            animMiddleDialogueManager = FindObjectOfType<AnimMiddleDialogueManager>();//那脚本
            animMiddleDialogueManager.OpenMiddleDialogue();//调中间谈话的方法.
            Debug.Log("FindEndingTag,PlayMiddleAnim");
        }
        else
        {
            animator.SetBool("IsOpen", true);
            Debug.Log("FindEndingTag,PlayMiddleAnim");
        }

    }

    void DisplaySentence()
    {
        Sentence sentenceToDisplay = currentSentences[activeSentence];
        textDisplay.text = sentenceToDisplay.sentence;// 将对话内容显示在 TextMeshProUGUI 对象上
        this.nameText.text = currentNameText;// 将名字显示在 TextMeshProUGUI 对象上 
        if (activeSentence == 0)
        {
            continueButton.SetActive(false);//开始前隐藏
            textDisplay.text = "";//清空句子
            Invoke("StartTyping", 0.6f);//延迟逐字播放
            // StartCoroutine(Type());//逐字播放
            continueButton.SetActive(false);//结束隐藏
        }

    }
    void StartTyping()
    {
        StartCoroutine(Type()); // 开始逐字播放
    }


    public void NextSentence()
    {
        continueButton.SetActive(false);//开始前隐藏
        activeSentence++;//下一句
        if (activeSentence < currentSentences.Length)
        {
            DisplaySentence();//如果有就显示     
            textDisplay.text = "";//清空句子
            StartCoroutine(Type());//逐字播放
        }
        else
        {
            Debug.Log("Conversation ended");
            textDisplay.text = "";

            if (Spawn.isTageWithEnding)//如果是是带有ending的标签.就播放这个Middle动画
            {
                animMiddleDialogueManager = FindObjectOfType<AnimMiddleDialogueManager>();//那脚本
                animMiddleDialogueManager.CloseTransition();//调中间谈话的方法.
            }
            else
            {
                animator.SetBool("IsOpen", false);
            }

            isActive = false;
            continueButton.SetActive(false);//结束隐藏
        }



    }

    public IEnumerator Type()
    {
        if (currentSentences != null && activeSentence >= 0 && activeSentence < currentSentences.Length)
        {
            foreach (char letter in currentSentences[activeSentence].sentence.ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        else
        {
            Debug.LogError("Error: Invalid index or currentSentences is null.");
        }
    }

}
