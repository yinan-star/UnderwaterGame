using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation = "";
    public bool isBuildButtonPressed = false;

    public GameObject shadowOfPrinto;//关掉剪影

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

        if (isCreatureButtonPressed)//只有在点击CreatureButton,才重置动画
        {
            animator.CrossFadeInFixedTime(currentAnimation, 0f);
        }
        // 将动画调整到指定的进度（0）
        isCreatureButtonPressed = false; // 重置按钮状态

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
