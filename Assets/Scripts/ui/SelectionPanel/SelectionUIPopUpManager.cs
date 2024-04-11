using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUIPopUpManager : MonoBehaviour
{
    public GameObject selectionUIPanel; // ����ѡ���������
    GameObject garbageObject;
    public static bool isCheckedGarbageTag = false;

    void Update()
    {
        // ��鳡�����Ƿ���ڴ��� "Garbage" ��ǩ����Ϸ����
        garbageObject = GameObject.FindWithTag("Garbage");
        CheckGarbageTag();

    }
    public void CheckGarbageTag()
    {
        // ����ҵ��˴��� "Garbage" ��ǩ����Ϸ����
        if (garbageObject != null)
        {
            Debug.Log("Found a game object with 'Garbage' tag.");
            selectionUIPanel.SetActive(false);
        }
        else
        {
            Debug.Log("No game object with 'Garbage' tag found.");
            // ����ѡ�����,����һ��Ϊtrue
            if (selectionUIPanel != null && !isCheckedGarbageTag)
            {
                selectionUIPanel.SetActive(true);
                isCheckedGarbageTag = true;
            }
        }
    }
    public void CloseSelectionPanel()
    {
        selectionUIPanel.SetActive(false);
        isCheckedGarbageTag = false;
    }


}
