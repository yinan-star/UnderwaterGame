using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUIPopUpManager : MonoBehaviour
{
    public GameObject selectionUIPanel; // ����ѡ���������

    void Start()
    {
        selectionUIPanel.SetActive(false);
    }

    public void OpenSelectionPanel()
    {
        selectionUIPanel.SetActive(true);//打开UI
    }
    public void CloseSelectionPanel()
    {
        selectionUIPanel.SetActive(false);
    }


}
