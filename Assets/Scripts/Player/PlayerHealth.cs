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
    public int healthThreshold = 6;
    private bool isPopupDisplayed = false;

    void Awake()
    {
        Debug.Log("BuildUI.SetActive(false); is called in Awake() method.");
        BuildUI.SetActive(false);
        SelectionUI.SetActive(false);
        findClosest = GetComponent<FindClosest>();
             

    }

    void Update()
    {
        //�ҵ�������ֵ��HealthBar
        if (findClosest != null)
        {
            currentHealth = findClosest.debrisCount;
            healthBar.SetHealth(currentHealth);     
        }

        //�ﵽ6��������UI
        if (currentHealth >= healthThreshold && !isPopupDisplayed)
        {         
            isPopupDisplayed = true;
            SelectionUI.SetActive(true);
        }
    }
  

}
