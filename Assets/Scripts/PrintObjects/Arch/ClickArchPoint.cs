using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArchPoint : MonoBehaviour
{
    public GameObject buildUIPanel02;
    public GameObject buildUIPanel03;
    public GameObject buildUIPanel01;
    public GameObject shadowOfArch;
    public void OpenBuildPanel02()
    {
        buildUIPanel02.SetActive(true);


    }
    public void OpenBuildPanel03()
    {
        buildUIPanel02.SetActive(true);

    }
    public void OpenBuildPanel01()
    {
        buildUIPanel02.SetActive(true);

    }
    public void ActiveShadowOfArch()
    {
        shadowOfArch.SetActive(true);
    }
}
