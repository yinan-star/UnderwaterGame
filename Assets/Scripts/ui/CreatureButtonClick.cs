using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureButtonClick : MonoBehaviour
{
    //public GameObject buildOvelayPanel; // �µ� UI ����
    private PlayerHealth playerHealth; // ���� PlayerHealth ���
    //public GameObject shadowOfPufferFish;//������Ӱ����

 
    void Awake()
    {
  
        // //buildUIPanel.SetActive(false);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenNewUIPanel);
        //shadowOfPufferFish.SetActive(false);

        // ��ȡ PlayerHealth ���
        playerHealth = FindObjectOfType<PlayerHealth>();

    }

    public void OpenNewUIPanel()
    {
        if (playerHealth != null)
        {
            playerHealth.SelectionUI.SetActive(false);
        }

        //buildOvelayPanel.SetActive(true);

    }
    //public void ActivePufferFish()
    //{
    //    shadowOfPufferFish.SetActive(true);
    //}
  
}
