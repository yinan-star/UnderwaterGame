using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteProgress : MonoBehaviour
{
    private Print build;
    //private CreatureButtonClick buttonClick;

    [SerializeField]
    private BuildCircle buildCircle;

    public float currentFill;
    //private bool isCreatrueButtonClicked = false; // 保存按钮是否被点击的状态
    void Start()
    {
        build = GetComponent<Print>();
        //buttonClick = FindObjectOfType<CreatureButtonClick>(); // 获取 CreatureButtonClick 组件
    
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
