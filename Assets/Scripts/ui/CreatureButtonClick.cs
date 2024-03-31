using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureButtonClick : MonoBehaviour
{
    public GameObject buildUIPanel; // 新的 UI 界面
    private PlayerHealth playerHealth; // 引用 PlayerHealth 组件
    public GameObject shadowOfPufferFish;//弹出剪影物体

 
    void Awake()
    {
  
        //buildUIPanel.SetActive(false);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenNewUIPanel);
        shadowOfPufferFish.SetActive(false);

        // 获取 PlayerHealth 组件
        playerHealth = FindObjectOfType<PlayerHealth>();

    }

    void OpenNewUIPanel()
    {
        if (playerHealth != null)
        {
            playerHealth.SelectionUI.SetActive(false);
        }

        buildUIPanel.SetActive(true);
       
    }
    public void ActivePufferFish()
    {
        shadowOfPufferFish.SetActive(true);
    }
  
}
