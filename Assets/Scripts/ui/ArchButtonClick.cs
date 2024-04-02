using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArchButtonClick : MonoBehaviour
{
    public GameObject buildUIPanel; // �µ� UI ����
    private PlayerHealth playerHealth; // ���� PlayerHealth ���
    public GameObject selectionUI;
    public GameObject shadowOfArch;//������Ӱ����

 
    void Awake()
    {
  
        // Button button = GetComponent<Button>();
        // button.onClick.AddListener(OpenNewUIPanel);

        // ��ȡ PlayerHealth ���
        // playerHealth = FindObjectOfType<PlayerHealth>();

    }

    public void OpenNewUIPanel()
    {   
        buildUIPanel.SetActive(true);
       
    }
    public void ActiveShadowOfArch()
    {
        shadowOfArch.SetActive(true);
    }
    public void CloseSelectionUI()//关掉选择界面
    {
        selectionUI.SetActive(false);

    }
  
}
