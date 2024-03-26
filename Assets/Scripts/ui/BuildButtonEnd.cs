using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonEnd : MonoBehaviour
{
    public SpriteProgress spriteProgress;
    public GameObject currentUIPanel; // 当前按钮界面
    private RandomMovement randomMovement; // 随机漫游脚本 
    private const string printedObjectsTag = "printedObjects";// 通过标签更改 spriteMask 的交互方式

    void Start()
    {

        spriteProgress = GetComponent<SpriteProgress>();//获取该游戏对象身上的其他脚本
       
        randomMovement = FindObjectOfType<RandomMovement>();//找挂有 randomMovement 脚本
       

    }

    void Update()
    {
        if (spriteProgress.currentFill >= 1.5f)
        {
            currentUIPanel.SetActive(false);//UI界面

            if (randomMovement != null)//随机移动
            {
                randomMovement.enabled = true;
            }

            SetMaskInteraction(SpriteMaskInteraction.None);//SpriteMask的交互
        }
        else
        {
            if (randomMovement != null)
            {
                randomMovement.enabled = false;           
            }

            SetMaskInteraction(SpriteMaskInteraction.VisibleInsideMask);
        }   
    }
    
    private void SetMaskInteraction(SpriteMaskInteraction interaction)
    {
        GameObject[] printedObjects = GameObject.FindGameObjectsWithTag(printedObjectsTag); //获取所有带有 printedObjects 标签的游戏对象数组
        foreach (GameObject obj in printedObjects)
        {
            //获取其 SpriteRenderer 组件
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.maskInteraction = interaction;//将传入的 interaction 参数给该游戏对象的 maskInteraction 属性
            }

            // 获取其 BoxCollider2D 组件
            BoxCollider2D boxCollider = obj.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                // 根据交互方式设置 BoxCollider2D 的启用状态
                if (interaction == SpriteMaskInteraction.None)
                {
                    boxCollider.enabled = true; 
                }
                else
                {
                    boxCollider.enabled = false; 
                }
            }
        }
    }
}
