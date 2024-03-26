using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureButtonClick : MonoBehaviour
{
    public GameObject buildUIPanel; // 新的 UI 界面
    public GameObject currentUIPanel; // 当前按钮界面


 
    void Awake()
    {
  
        //buildUIPanel.SetActive(false);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenNewUIPanel);
    }


    void OpenNewUIPanel()
    {
        currentUIPanel.SetActive(false);
        buildUIPanel.SetActive(true);
    }
}
