using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private FindClosest findClosest;
    public HealthBar healthBar;
    public int currentHealth;

    //public GameObject SelectionUI;
    public int healthThreshold = 9;
    public bool healthChecked = false;
    public GameObject[] ArchPointbuttons; // 三个要显示的按钮

    public GameObject buildOverlayPanel;


    //弹窗达到条件后只执行一次
    private bool isPrefaceTrigger = false;
    private bool isSelectionTrigger = false;

   

    void Start()
    {

        //SelectionUI.SetActive(false);
        findClosest = GetComponent<FindClosest>();

        foreach (GameObject button in ArchPointbuttons)
        {
            button.SetActive(false);//游戏开始是关着的
            Debug.Log("ArchPoints are Closed");
        }

        buildOverlayPanel.SetActive(false);

    }

    void Update()
    {
        StartDialogue();
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
            //SelectionUI.SetActive(true);//弹UI
            //healthChecked = true;//�Ѿ�������ֵ�ˣ�����Ҫÿ֡�����
            GameObject selectionPanelTrigger = GameObject.FindGameObjectWithTag("selectionPanel");
            if (!isSelectionTrigger)
            {
                if (selectionPanelTrigger != null)
                {   // 获取游戏SelectionButton对象上的 DialogueTrigger 组件
                    DialogueTrigger selectionDialogue = selectionPanelTrigger.GetComponent<DialogueTrigger>();
                    if (selectionDialogue != null)
                    {
                        selectionDialogue.StartDialogue();
                    }
                }
                isSelectionTrigger = true;//已经弹过不要重复弹
            }
            
        }
        //if (!(currentHealth % healthThreshold == 0))
        //{
        //    healthChecked = false;
        //}     

    }
    
    public void StartDialogue()
    {
        if (currentHealth == 0)
        {
            GameObject prefaceDialogueTrigger = GameObject.FindGameObjectWithTag("prefaceTrigger");
            if (!isPrefaceTrigger && prefaceDialogueTrigger != null)
            {
                DialogueTrigger prefaceDialogue = prefaceDialogueTrigger.GetComponent<DialogueTrigger>();
                if (prefaceDialogue != null)
                {
                    prefaceDialogue.StartDialogue();
                    isPrefaceTrigger = true;//弹一次
                }
            }

        }
    }
   


}
