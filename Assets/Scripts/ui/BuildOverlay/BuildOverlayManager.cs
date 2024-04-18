using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOverlayManager : MonoBehaviour
{
    public GameObject buildOvelayPanel;
    public GameObject buildTargetPanel;
    private void Start()
    {
        buildTargetPanel.SetActive(true);//��Ϸ��ʼ��ʱ���ǹصġ�
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
        buildTargetPanel.SetActive(false);//���Build��ر�
        Debug.Log("CloseBuildTarget");
    }
}
