using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation = "";
    private bool isButtonPressed = false;
    private bool isPrintedAllowed = false;

    private SelectPrintoManager selectPrintoManager; //���Ѿ�ѡ��Ҫ��ӡ����������
    public PrintedColorObjectsDatabase printoColorData;//�ô�ӡ��������������
    public GameObject shadowOfPrinto;//�ص���Ӱ

   

    //private void OnMouseOver()
    //{
        
    //}


    void Update()
    {
        //Input.mousePosition

    //Input.GetMouseButton(0)
    //if (Input.GetKey(KeyCode.Space))
    //{
    //    ChangeAnimationState("PufferFishPrint");
    //    animator.speed = 1;
    //}     
    //else
    //{
    //    animator.speed = 0;
    //}

    selectPrintoManager = FindObjectOfType<SelectPrintoManager>();
        if(selectPrintoManager != null)
        {
            CheckPrinto();//���Ҫ��ӡ�������Ƿ�ƥ��
        }
        
        if (isButtonPressed && isPrintedAllowed)
        {

            ChangeAnimationState("PufferFishPrint");
            animator.speed = 1;
        }
        else
        {
            animator.speed = 0;
        }

        GetAnimationProgress();

    }

    public void ButtonAction()
    {
        isButtonPressed = true;
    }

    public void ButtonReleaseAction()
    {
        isButtonPressed = false;
    }

    void ChangeAnimationState(string animation)
    {
        if (currentAnimation != animation) //current != target
        {
            currentAnimation = animation;
            animator.Play(animation);
        }
    }
    public void CheckPrinto()
    {
        int selectedPrinto = selectPrintoManager.selectedPrinto;//��ѡ��Ҫ�������ֵ
        for (int i = 0; i < printoColorData.PrintoColorCount; i++)//�ô�ӡ�������������������ֵ
        {
            // ��鵱ǰ����ֵ�Ƿ��� selectedPrinto ��ͬ
            if (i == selectedPrinto)
            {
                isPrintedAllowed = true;
            }

        }

    }

    public void DestroyShadowOfPrinto()
    {
        shadowOfPrinto.SetActive(false);
    }

    public float GetAnimationProgress()
    {

        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

 
}
