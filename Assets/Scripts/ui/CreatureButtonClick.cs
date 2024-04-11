using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureButtonClick : MonoBehaviour
{

    private PlayerHealth playerHealth; 


 
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenNewUIPanel);
    

        // ��ȡ PlayerHealth ���
        playerHealth = FindObjectOfType<PlayerHealth>();

    }

    public void OpenNewUIPanel()
    {
        if (playerHealth != null)
        {
            //playerHealth.SelectionUI.SetActive(false);
        }

    }

  
}
