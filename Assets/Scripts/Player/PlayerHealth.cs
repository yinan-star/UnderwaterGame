using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    private FindClosest findClosest;
    public HealthBar healthBar;
    public int currentHealth;
    
    public GameObject SelectionUI;
    public GameObject shadowOfPrinto;
    // public GameObject shadowOfArch;
    public int healthThreshold = 6;
    public bool healthChecked = false;
    public GameObject[] ArchPointbuttons; // 三个要显示的按钮

    // public GameObject buildPanel;
    void Start()
    {
        
        SelectionUI.SetActive(false);
        findClosest = GetComponent<FindClosest>();
        shadowOfPrinto.SetActive(false);
        // shadowOfArch.SetActive(false);
        foreach (GameObject button in ArchPointbuttons)
        {
            button.SetActive(false);//游戏开始是关着的
            Debug.Log("ArchPoints are Closed");
        }
        // buildPanel.SetActive(false);


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
        }
        if(!(currentHealth % healthThreshold == 0))
        {
            healthChecked = false;
        }
       
    }


}
