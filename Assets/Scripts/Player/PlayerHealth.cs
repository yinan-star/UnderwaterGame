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
        //找到垃圾的值给HealthBar
        if (findClosest != null)
        {
            currentHealth = findClosest.debrisCount;
            healthBar.SetHealth(currentHealth);     
        }

        //达到6个垃圾弹UI
        if (currentHealth >= healthThreshold && !isPopupDisplayed)
        {         
            isPopupDisplayed = true;
            SelectionUI.SetActive(true);
        }
    }
  

}
