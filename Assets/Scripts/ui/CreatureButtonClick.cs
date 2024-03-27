using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureButtonClick : MonoBehaviour
{
    public GameObject buildUIPanel; // �µ� UI ����
    public GameObject currentUIPanel; // ��ǰ��ť����
    public GameObject shadowOfPufferFish;//������Ӱ����

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
