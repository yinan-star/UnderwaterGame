using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButtons : MonoBehaviour
{
    public Transform player; // 玩家的Transform组件
    public Transform[] buttons; // 按钮的Transform组件
    public float maxDistance = 10f; // 最大距离
    public static bool isPressed = false;
    //播一次、
    public static bool playOnce = false;
    private void Start()
    {
        isPressed = false;
        playOnce = false;
        // 获取音频管理器
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    //调音乐
    AudioManager audioManager;
    public void PlaySound()
    {
       
        audioManager.PlaySFX(audioManager.clickButton);
    }
    public void PlayPrintSound()
    {
       
        audioManager.PlaySFX(audioManager.printProcess);
    }
    public void PlayNextSound()
    {
       
        audioManager.PlaySFX(audioManager.clickNextButton);
    }
    public void PlayButtonSound()
    {
       
        audioManager.PlaySFX(audioManager.clickButton);
    }
 
    void Update()
    {
        if(isPressed)
        {        
            float maxVolume = 0f;
            foreach (Transform btn in buttons)
            {
                // 计算玩家与按钮之间的距离
                float distance = Vector3.Distance(player.position, btn.position);

                // 根据距离调整音量
                float volume = 1f - Mathf.Clamp01(distance / maxDistance)* 1.5f;

                if (volume > maxVolume)
                {
                    maxVolume = volume;
                }              
            }
            // 根据最大音量设置音量
            audioManager.SFXSourceLoop.volume = maxVolume;
        }
 
            
    }
    public void ArchButtonPresse()
    {
        if(!MiniArchUIManager.isArchPointListZero)
        {
            isPressed = true;//按了ArchButton后就计算距离播放音乐,t
            // 播放 closeToArchButton 音频                      
        }
        else
        {
            isPressed = false;
        }
    }

}
