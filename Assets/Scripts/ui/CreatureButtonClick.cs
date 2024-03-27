using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureButtonClick : MonoBehaviour
{
    public GameObject buildUIPanel; // 新的 UI 界面
    public GameObject currentUIPanel; // 当前按钮界面
    public GameObject shadowOfPufferFish;//弹出剪影物体

    void Awake()
    {
  
        //buildUIPanel.SetActive(false);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenNewUIPanel);
        shadowOfPufferFish.SetActive(false);
    }

    void OpenNewUIPanel()
    {
        currentUIPanel.SetActive(false);
        buildUIPanel.SetActive(true);
    }
    public void ActivePufferFish()
    {
        shadowOfPufferFish.SetActive(true);
    }
}
