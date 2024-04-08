using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControls : MonoBehaviour
{
    public GameObject dialogueControl;
    public GameObject collectControl;
    private GameObject[] garbageObjects;

    void Start()
    {
        dialogueControl.SetActive(false);
        collectControl.SetActive(false);


    }


    // Update is called once per frame
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

        // ��鳡�����Ƿ���ڴ��� "garbage" ��ǩ�Ķ���
        garbageObjects = GameObject.FindGameObjectsWithTag("Garbage");
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
