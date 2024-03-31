using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation = "";
    public bool isBuildButtonPressed = false;

    public GameObject shadowOfPrinto;//�ص���Ӱ

    private bool isCreatureButtonPressed = false;
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
      
        
        if (isBuildButtonPressed)//&& isPrintedAllowed
        {

            ChangeAnimationState("PufferFishPrint");
            animator.speed = 1;         
        }
        else
        {
            animator.speed = 0;
        }

        GetAnimationProgress();      
        RestartAnimation();

    }


    public void ButtonAction()//BuildButtonAction
    {
        isBuildButtonPressed = true;
    }


    public void CreatureButtonAction()
    {
        isCreatureButtonPressed = true;
    }

    public void RestartAnimation()
    {

        if (isCreatureButtonPressed)//ֻ���ڵ��CreatureButton,�����ö���
        {
            animator.CrossFadeInFixedTime(currentAnimation, 0f);
        }
        // ������������ָ���Ľ��ȣ�0��
        isCreatureButtonPressed = false; // ���ð�ť״̬

    }

    void ChangeAnimationState(string animation)
    {
        if (currentAnimation != animation) //current != target
        {
            currentAnimation = animation;
            animator.Play(animation);
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
