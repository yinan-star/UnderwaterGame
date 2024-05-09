using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchPointManager : MonoBehaviour
{
    //public GameObject[] ArchPointbuttons; // 三个要显示的按钮.
    //数组和List的区别就是List可以动态添加或删除列表的对象.
    public List<GameObject> activeArchPointButtons = new(); // 存储当前激活的按钮
    public List<GameObject> allArchPointButtons = new(); // 所有的按钮
    //调音乐
    AudioManager audioManager;
    void Start()
    {
        // 将所有按钮添加到激活列表中
        activeArchPointButtons.AddRange(allArchPointButtons);
        // 获取音频管理器
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void ActiveArchPoints()
    {
        // 激活三个ArchPoint按钮
        foreach (GameObject button in activeArchPointButtons)
        {
            button.SetActive(true);
            audioManager.SFXSourceLoop.clip = audioManager.closeToArchButton;//将Close音乐给Loop的Clip
            audioManager.SFXSourceLoop.Play();//让它播放
        }
    
    }

    public void RemoveArchPoints(GameObject buttonToClose)
    {
      
        // 从激活列表中移除指定按钮
        activeArchPointButtons.Remove(buttonToClose);

    }
    public void CloseArchPoints()
    {
        //关闭所有Arch按钮
        foreach (GameObject button in allArchPointButtons)
        {
            
            Debug.Log("CloseArchScource");
            button.SetActive(false);
            audioManager.SFXSourceLoop.Stop();//停止播音乐

        }
        
    }
}
