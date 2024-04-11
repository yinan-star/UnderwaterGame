using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitButtonsSelection : MonoBehaviour
{
    public Button buttonCreature;
    public Button buttonArch;
    public Button buttonFood;
    private PlayerHealth playerHealth;
    void Start(){
        playerHealth = FindObjectOfType<PlayerHealth>();
    }


    void Update()
    {
        if (DialogueManager.isActive == true)//如果在弹窗,按钮组件禁用
        {
            buttonCreature.enabled = false;

            buttonArch.enabled = false;

            buttonFood.enabled = false;
        }
        else//如果没弹窗
        {
            buttonCreature.enabled = true;
            
            if (playerHealth.currentHealth >= 12)
            {
                buttonArch.enabled = true;
            }
            // buttonFood.enabled = true;
        }

    }

}
