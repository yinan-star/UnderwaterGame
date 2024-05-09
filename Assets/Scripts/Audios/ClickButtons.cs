using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButtons : MonoBehaviour
{
    public Transform player; // ��ҵ�Transform���
    public Transform[] buttons; // ��ť��Transform���
    public float maxDistance = 10f; // ������
    public static bool isPressed = false;
    //��һ�Ρ�
    public static bool playOnce = false;
    private void Start()
    {
        isPressed = false;
        playOnce = false;
        // ��ȡ��Ƶ������
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    //������
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
                // ��������밴ť֮��ľ���
                float distance = Vector3.Distance(player.position, btn.position);

                // ���ݾ����������
                float volume = 1f - Mathf.Clamp01(distance / maxDistance)* 1.5f;

                if (volume > maxVolume)
                {
                    maxVolume = volume;
                }              
            }
            // �������������������
            audioManager.SFXSourceLoop.volume = maxVolume;
        }
 
            
    }
    public void ArchButtonPresse()
    {
        if(!MiniArchUIManager.isArchPointListZero)
        {
            isPressed = true;//����ArchButton��ͼ�����벥������,t
            // ���� closeToArchButton ��Ƶ                      
        }
        else
        {
            isPressed = false;
        }
    }

}
