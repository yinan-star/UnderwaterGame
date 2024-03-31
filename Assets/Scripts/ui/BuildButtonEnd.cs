using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonEnd : MonoBehaviour
{
    public SpriteProgress spriteProgress;
    public GameObject BuildPanel; // 当前按钮界面   
    private Spawn spawnScript;
    private bool hasSpawnedObjects = false; 
    public bool buildPanelClosed = false; // 标志是否已经关闭了 BuildPanel
    private Print printScript;
    private CreatureSpawn creatureSpawn;

    void Start()
    {

        spriteProgress = GetComponent<SpriteProgress>();//获取该游戏对象身上的其他脚本
        printScript = GetComponent<Print>();//获取Print脚本   
        spawnScript = FindObjectOfType<Spawn>();//请求垃圾Spwan脚本
        creatureSpawn = FindObjectOfType<CreatureSpawn>();



    }

    private void Update()
    {
        CheckRandomMovement();
        if (spriteProgress.currentFill >= 1.5f)
        {                
            if (!hasSpawnedObjects && spawnScript != null)
            {
                spawnScript.SpawnObjects();// 请求生成垃圾的方法
                hasSpawnedObjects = true; // 标记已生成    
            }

            if (!buildPanelClosed)
            {
                // 关闭 UI 界面
                BuildPanel.SetActive(false);
                buildPanelClosed = true; // 当关掉BuildPanel时标记已关闭
                printScript.isBuildButtonPressed = false;//关闭BuildPanel的时候重置Build按钮状态
            }

        }
        else
        {           
            hasSpawnedObjects = false; // 标记没生成  
            buildPanelClosed = false;
        }
    }
    private void CheckRandomMovement()
    {
        if (creatureSpawn.spawnedCreature != null)
        {
            RandomMovement randomMovement = creatureSpawn.spawnedCreature.GetComponent<RandomMovement>();
            SpriteRenderer spriteRenderer = creatureSpawn.spawnedCreature.GetComponent<SpriteRenderer>();
            Vector3 scale = spriteRenderer.transform.localScale;
            if (!creatureSpawn.randomMovementEnabled) // 只有当RandomMovement未被启用时才执行以下代码
            {
                if (randomMovement != null && spriteProgress.currentFill >= 1.5f)
                {
                    randomMovement.enabled = true;
                    creatureSpawn.randomMovementEnabled = true; // 标记RandomMovement已被启用
                    spriteRenderer.maskInteraction = SpriteMaskInteraction.None;//SpriteMask的交互                   

                }
                else
                {
                    randomMovement.enabled = false;
                    spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;//SpriteMask的交互
                }
               
            }
               
        }       

    }

}
