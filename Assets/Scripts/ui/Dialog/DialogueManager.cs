using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    string[] currentSentences;
    string currentNameText;



    public static bool isActive = false;

    public GameObject continueButton;
    public Animator animator;


    void Start()
    {
        StartCoroutine(Type());
        animator.SetBool("IsOpen", true);
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }   
    }

    public void NextSentence()
    {
        
       continueButton.SetActive(false);//开始前隐藏
       if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            animator.SetBool("IsOpen", false); 
        }
        continueButton.SetActive(false);//结束隐藏
        
        
    }

    public IEnumerator Type()
    {           
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }          
    }

}
