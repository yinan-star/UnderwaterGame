using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePrintObject : MonoBehaviour
{
    public GameObject pufferFish;
    public GameObject YellowLongFish;
    public GameObject blueFish;
    public void ActivatePufferFish()
    {
        pufferFish.SetActive(true);
        YellowLongFish.SetActive(false);
        blueFish.SetActive(false);
    }
}
