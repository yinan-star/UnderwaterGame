using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUIPopUpManager : MonoBehaviour
{
    public GameObject selectionUIPanel; // ����ѡ���������
    public static bool isOpenSelectionUI = false;

    void Start()
    {
        selectionUIPanel.SetActive(false);
        isOpenSelectionUI = false;
    }

    public void OpenSelectionPanel()
    {
        selectionUIPanel.SetActive(true);//打开UI
        isOpenSelectionUI = true;
    }
    public void CloseSelectionPanel()
    {
        selectionUIPanel.SetActive(false);
        isOpenSelectionUI = false;
    }


}
