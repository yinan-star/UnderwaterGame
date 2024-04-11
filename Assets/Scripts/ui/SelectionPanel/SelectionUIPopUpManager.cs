using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUIPopUpManager : MonoBehaviour
{
    public GameObject selectionUIPanel; // 弹出选择界面的面板
    GameObject garbageObject;
    public static bool isCheckedGarbageTag = false;

    void Update()
    {
        // 检查场景中是否存在带有 "Garbage" 标签的游戏对象
        garbageObject = GameObject.FindWithTag("Garbage");
        CheckGarbageTag();

    }
    public void CheckGarbageTag()
    {
        // 如果找到了带有 "Garbage" 标签的游戏对象
        if (garbageObject != null)
        {
            Debug.Log("Found a game object with 'Garbage' tag.");
            selectionUIPanel.SetActive(false);
        }
        else
        {
            Debug.Log("No game object with 'Garbage' tag found.");
            // 弹出选择界面,设置一次为true
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
