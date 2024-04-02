using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchPointManager : MonoBehaviour
{
    public GameObject[] ArchPointbuttons; // 三个要显示的按钮
    void Start()
    {
        foreach (GameObject button in ArchPointbuttons)
        {
            button.SetActive(false);//游戏开始是关着的
        }
    }

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
