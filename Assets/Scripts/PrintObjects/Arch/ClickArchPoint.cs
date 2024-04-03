using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArchPoint : MonoBehaviour
{
    public GameObject shadowOfArch;
  
    public void ActiveShadowOfArch()
    {
        shadowOfArch.SetActive(true);
    }
}
