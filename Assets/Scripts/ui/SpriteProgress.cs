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
    }

    void Update()
    {
        //把progress的值给buildCircle.Fill方法
        if (build && uIInstantiateManager != null)
        {
            float progress = build.GetAnimationProgress();//把SpriteMask动画的进度给BuildCircle的Fill.
            buildPanelClone = uIInstantiateManager.buildPanelClone;//新生成的BuildPanel
            if (buildPanelClone != null)
            {
                buildCircle = buildPanelClone.GetComponent<BuildCircle>();//拿BuildPanel身上的BuildCircle脚本
                if (progress >= 2f)
                {
                    currentFill = 2f;
                    buildCircle.Fill(currentFill);
                }
                else
                {
                    currentFill = progress;
                    buildCircle.Fill(currentFill);
                }
            }
        }
    }

}
