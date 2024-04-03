using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchPointManager : MonoBehaviour
{
    public GameObject[] ArchPointbuttons; // 三个要显示的按钮
    void Update()
    {
        
    }
    public void ActiveArchPoints()
    {
        // 激活三个ArchPoint按钮
        foreach (GameObject button in ArchPointbuttons)
        {
            button.SetActive(true);
        }
    }

    public void CloseArchPoints()
    {
        // 关闭三个ArchPoint按钮
        foreach (GameObject button in ArchPointbuttons)
        {
            button.SetActive(false);
        }

    }
}
