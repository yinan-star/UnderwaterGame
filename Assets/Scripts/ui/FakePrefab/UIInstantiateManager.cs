using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class UIInstantiateManager : MonoBehaviour
{
    //BuildUI Instantiate
    [SerializeField] private GameObject buildPanel;
    public GameObject buildPanelClone;
    public Transform[] transforms;
    public Transform canvasTransform; // 参考 Canvas 的 Transform
    private ShadowArchManager shadowArchManager;

    private void Start()
    {
        // buildPanelClone = Instantiate(buildPanel, this.transform);//在canvas的位置生成新的Build.
        buildPanelClone = null;//假设他就是null

       
    }
    public void SpawnBuildPanel01()
    {

        buildPanelClone = Instantiate(buildPanel, transforms[0].position, Quaternion.identity);//在transforms的第一个索引的位置生成新的Build.       
        SetCanvasAsParent();
       
    }
    public void SpawnBuildPanel02()
    {

        buildPanelClone = Instantiate(buildPanel, transforms[1].position, Quaternion.identity);            
        SetCanvasAsParent();
     
    }
    public void SpawnBuildPanel03()
    {

        buildPanelClone = Instantiate(buildPanel, transforms[2].position, Quaternion.identity);      
        SetCanvasAsParent();
    

    }


    public void SetCanvasAsParent()
    {
        // 获取 ShadowArchManager 组件
        shadowArchManager = FindObjectOfType<ShadowArchManager>();
        // 设置 buildPanelClone 的父对象为 Canvas
        if (canvasTransform != null)
        {
            buildPanelClone.transform.SetParent(canvasTransform, false); // 设置为 false 表示不改变局部坐标
        }
    }

   
    public void AddNextButtonEvent()
    {
        // 获取 ShadowArchManager 组件
        shadowArchManager = FindObjectOfType<ShadowArchManager>();
        if (shadowArchManager != null)
        {
            shadowArchManager.NextPrinto();
        }
    }
    public void AddPrevButtonEvent()
    {
        shadowArchManager = FindObjectOfType<ShadowArchManager>();
        if (shadowArchManager != null)
        {
            shadowArchManager.PreviousPrinto();
        }
    }


}