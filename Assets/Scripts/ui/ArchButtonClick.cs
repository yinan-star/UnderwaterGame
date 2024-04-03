using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArchButtonClick : MonoBehaviour
{
    //public GameObject buildUIPanel02; 
    //public GameObject buildUIPanel03; 
    //public GameObject buildUIPanel01; 
    //private PlayerHealth playerHealth; // ���� PlayerHealth ���
    public GameObject selectionUI;
    

 
    void Awake()
    {
  
        // Button button = GetComponent<Button>();
        // button.onClick.AddListener(OpenNewUIPanel);

        // ��ȡ PlayerHealth ���
        // playerHealth = FindObjectOfType<PlayerHealth>();

    }

   
    public void CloseSelectionUI()//关掉选择界面
    {
        selectionUI.SetActive(false);

    }
  
}
