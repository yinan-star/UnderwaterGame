using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePrintObject : MonoBehaviour
{
    public GameObject pufferFish;
    public void ActivatePufferFishColor()
    {
        pufferFish.SetActive(true);
    }
}
