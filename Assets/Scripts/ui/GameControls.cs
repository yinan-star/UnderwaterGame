using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControls : MonoBehaviour
{
    public GameObject dialogueControl;
    public GameObject collectControl;
    private PickUp[] garbageObjects;

    void Start()
    {
        dialogueControl.SetActive(false);
        collectControl.SetActive(false);


    }

    void Update()
    {
        if (DialogueManager.isActive == true)
        {
            dialogueControl.SetActive(true);
        }
        else
        {
            dialogueControl.SetActive(false);
        }

        // 检查场景中是否存在带有 "PickUp" 脚本的对象（垃圾）
        garbageObjects = FindObjectsOfType<PickUp>();
        if (garbageObjects.Length > 0 && DialogueManager.isActive == false)
        {
            collectControl.SetActive(true);

        } 
        else
        {
            collectControl.SetActive(false);
        }

    }
}
