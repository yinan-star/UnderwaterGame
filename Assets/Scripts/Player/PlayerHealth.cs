using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    private FindClosest findClosest;
    public HealthBar healthBar;
    public int currentHealth;
    
    public GameObject SelectionUI;
    public int healthThreshold = 6;
    public bool healthChecked = false;
    public GameObject[] ArchPointbuttons; // 三个要显示的按钮

    public GameObject buildOverlayPanel;

    private GameObject selectionPanelTrigger;
    private bool isTrigger = false;
    void Start()
    {
        
        SelectionUI.SetActive(false);
        findClosest = GetComponent<FindClosest>();
      
        foreach (GameObject button in ArchPointbuttons)
        {
            button.SetActive(false);//游戏开始是关着的
            Debug.Log("ArchPoints are Closed");
        }

        buildOverlayPanel.SetActive(false);

        selectionPanelTrigger = GameObject.FindGameObjectWithTag("selectionPanel");//通过标签，找到该对象身上的Dialogue.
    }

    void Update()
    {
        //�ҵ�������ֵ��HealthBar
        if (findClosest != null)
        {
            currentHealth = findClosest.debrisCount;
            healthBar.SetHealth(currentHealth);     
        }
        CheckHealthThreshold();

    }
    public void CheckHealthThreshold()
    {
        if (currentHealth >= healthThreshold && currentHealth % healthThreshold == 0 && !healthChecked)
        {
            SelectionUI.SetActive(true);
            healthChecked = true;//�Ѿ�������ֵ�ˣ�����Ҫÿ֡�����
            if (!isTrigger && selectionPanelTrigger != null)
            {
                // 获取游戏对象上的 DialogueTrigger 组件
                DialogueTrigger dialogueTrigger = selectionPanelTrigger.GetComponent<DialogueTrigger>();
                if(dialogueTrigger != null)
                {                 
                    dialogueTrigger.TriggerDialogue();
                    isTrigger = true;//已经弹过不要重复弹
                }              
            }          
        }
        if(!(currentHealth % healthThreshold == 0))
        {
            healthChecked = false;
        }
       
    }


}
