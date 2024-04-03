using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteProgress : MonoBehaviour
{
    private Print build;
    //private CreatureButtonClick buttonClick;

    //private SpawnBuildPanel buildPanelSpawn;
    private BuildCircle buildCircle;
    private UIInstantiateManager uIInstantiateManager;

    public float currentFill;
    //private bool isCreatrueButtonClicked = false; // 保存按钮是否被点击的状态
    void Start()
    {
        build = GetComponent<Print>();
        //buttonClick = FindObjectOfType<CreatureButtonClick>(); // 获取 CreatureButtonClick 组件
        //buildPanelSpawn = FindObjectOfType<SpawnBuildPanel>();//获取SpawnBuildPanel脚本
        //buildCircle = buildPanelSpawn.buildPanel.GetComponent<BuildCircle>();//从预制体里面拿buildCirclr脚本
        GameObject buildPanelClone = uIInstantiateManager.buildPanelClone;
        buildCircle = buildPanelClone.GetComponent<BuildCircle>();


    }

    void Update()
    {
        if (build != null)
        {
            float progress = build.GetAnimationProgress();
            if (progress >= 2f)
            {
                currentFill = 2f;
            }
            else
            {
                currentFill = progress;
            }
            // 将当前动画的进度赋值给 currentFill，用于更新进度条             
            buildCircle.Fill(currentFill);
        }
    }

    // 设置按钮被点击的状态
    //public void SetButtonClicked()
    //{
    //    isCreatrueButtonClicked = true;
    //}

}
