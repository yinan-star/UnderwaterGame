using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteProgress : MonoBehaviour
{
    private Print build;
    private BuildCircle buildCircle;
    private UIInstantiateManager uIInstantiateManager;

    private GameObject buildPanelClone;

    public float currentFill;

    void Start()
    {
        build = GetComponent<Print>();
        uIInstantiateManager = FindObjectOfType<UIInstantiateManager>();
        // 确保 uIInstantiateManager 不为 null，并且 buildPanelClone 已经被初始化
        if (uIInstantiateManager != null)
        {
            buildPanelClone = uIInstantiateManager.buildPanelClone;//新生成的BuildPanel
            if (buildPanelClone != null)
            {
                buildCircle = buildPanelClone.GetComponent<BuildCircle>();//拿BuildPanel身上的BuildCircle脚本
            }
        }


    }
    // public void CheckIsSpawnedBuildPanel()
    // {
    //     // 在此处检查 buildPanelClone 是否已经生成
    //     if (uIInstantiateManager != null && uIInstantiateManager.buildPanelClone != null)
    //     {
    //         buildPanelClone = uIInstantiateManager.buildPanelClone;
    //         buildCircle = buildPanelClone.GetComponent<BuildCircle>();
    //     }

    // }

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
            buildCircle.Fill(currentFill);


        }
    }





}
