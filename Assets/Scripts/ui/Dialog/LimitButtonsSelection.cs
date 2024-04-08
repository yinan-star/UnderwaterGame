using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitButtonsSelection : MonoBehaviour
{
    public Button buttonCreature;
    public Button buttonArch;
    public Button buttonFood;


    void Update()
    {
        if (DialogueManager.isActive == true)//如果在弹窗,按钮组件禁用
        {
            buttonCreature.enabled = false;

            buttonArch.enabled = false;

            buttonFood.enabled = false;
        }
        else
        {
            buttonCreature.enabled = true;

            buttonArch.enabled = true;

            buttonFood.enabled = true;
        }
    }

}
