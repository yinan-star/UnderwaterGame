using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    private FindClosest findClosest;
    public HealthBar healthBar;
    public int currentHealth;
    
    public GameObject SelectionUI;
    public GameObject BuildUI;
    public GameObject shadowOfPrinto;
    public int healthThreshold = 6;
    public bool healthChecked = false; // 检查健康值的标志
    void Start()
    {
        BuildUI.SetActive(false);
        SelectionUI.SetActive(false);
        findClosest = GetComponent<FindClosest>();
        shadowOfPrinto.SetActive(false);
                 

    }

    void Update()
    {
        //找到垃圾的值给HealthBar
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
            healthChecked = true;//已经检查过阈值了，不需要每帧检查了
        }
        if(!(currentHealth % healthThreshold == 0))
        {
            healthChecked = false;
        }
       
    }


}
