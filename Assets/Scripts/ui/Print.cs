using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation = "";
    private bool isButtonPressed = false;
  
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    ChangeAnimationState("PufferFishPrint");
        //    animator.speed = 1;
        //}     
        //else
        //{
        //    animator.speed = 0;
        //}
        if (isButtonPressed)
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
        Debug.Log("Button pressed");
    }

    public void ButtonReleaseAction()
    {
        isButtonPressed = false;
        Debug.Log("Button released");
    }


    void ChangeAnimationState(string animation)
    {
        if (currentAnimation != animation) //current != target
        {
            currentAnimation = animation;
            animator.Play(animation);
        }
    }

    public float GetAnimationProgress()
    {

        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    
}
