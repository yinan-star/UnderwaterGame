using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArchButtonClick : MonoBehaviour
{
    public GameObject buildUIPanel; // �µ� UI ����
    private PlayerHealth playerHealth; // ���� PlayerHealth ���
    public GameObject shadowOfArch;//������Ӱ����

 
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
            playerHealth.SelectionUI.SetActive(false);
        }

        buildUIPanel.SetActive(true);
       
    }
    public void ActiveShadowOfArch()
    {
        shadowOfArch.SetActive(true);
    }
  
}
