using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureButtonClick : MonoBehaviour
{
    public GameObject buildUIPanel; // �µ� UI ����
    public GameObject currentUIPanel; // ��ǰ��ť����


 
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
