using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColorArch : MonoBehaviour
{
  
    public GameObject archSpawn;
    public void ActivateArchColor()
    {
        archSpawn.SetActive(true);
        Debug.Log("archSpawn is activated now");
    }
}
