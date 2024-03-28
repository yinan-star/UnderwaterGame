using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation = "";
    private bool isButtonPressed = false;
    private bool isPrintedAllowed = false;

    private SelectPrintoManager selectPrintoManager; //拿已经选择要打印的物体数据
    public PrintedColorObjectsDatabase printoColorData;//拿打印出来的物体数据
    public GameObject shadowOfPrinto;//关掉剪影

   

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
            CheckPrinto();//检查要打印的物体是否匹配
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
        int selectedPrinto = selectPrintoManager.selectedPrinto;//拿选择要打的索引值
        for (int i = 0; i < printoColorData.PrintoColorCount; i++)//拿打印出来的物体的所有索引值
        {
            // 检查当前索引值是否与 selectedPrinto 相同
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
