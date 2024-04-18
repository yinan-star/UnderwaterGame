using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOverlayManager : MonoBehaviour
{
    public GameObject buildOvelayPanel;
    public GameObject buildTargetPanel;
    private void Start()
    {
        buildTargetPanel.SetActive(true);//游戏开始的时候是关的。
    }


    public void OpenBuildOverlayPanel()
    {
        buildOvelayPanel.SetActive(true);
        buildTargetPanel.SetActive(true);
        Debug.Log("OpenBuildPanelandTarget");


    }
    public void CloseBuildOverlayPanel()
    {
        buildOvelayPanel.SetActive(false);
        Debug.Log("CloseBuildPanel");
    }
    public void CloseBuildTarget()
    {
        buildTargetPanel.SetActive(false);//点击Build后关闭
        Debug.Log("CloseBuildTarget");
    }
}
