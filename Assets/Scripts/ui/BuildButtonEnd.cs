using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonEnd : MonoBehaviour
{
    public SpriteProgress spriteProgress;
    public GameObject buildOverlayPanel;  
    private Spawn spawnScript;
    private bool hasSpawnedObjects = false;
    public bool buildPanelClosed = false;
    public bool buildOverlayPanelClosed = false;
    private Print printScript;
    private CreatureSpawn creatureSpawn;
    private ArchSpawn archSpawn;

    //拿BuildPanel
    private UIInstantiateManager uIInstantiateManager;
    private GameObject buildPanelClone;

    void Start()
    {

        spriteProgress = GetComponent<SpriteProgress>();
        printScript = GetComponent<Print>(); 
        spawnScript = FindObjectOfType<Spawn>();
        creatureSpawn = FindObjectOfType<CreatureSpawn>();
        archSpawn = FindObjectOfType<ArchSpawn>();

        //拿生成BuildPanel的脚本
        uIInstantiateManager = FindObjectOfType<UIInstantiateManager>();

    }

    private void Update()
    {
        CheckRandomMovement();
        CheckRigidBody();
        if (spriteProgress.currentFill >= 1.5f)
        {
            //生成垃圾
            if (!hasSpawnedObjects && spawnScript != null)//Instantiate垃圾
            {
                spawnScript.SpawnObjects();
                hasSpawnedObjects = true;
            }
            //关掉BuildPanel
            if (!buildPanelClosed && uIInstantiateManager != null)//如果没有关掉BuildPanel,就关掉
            {
                buildPanelClone = uIInstantiateManager.buildPanelClone;//新生成的BuildPanel
                if (buildPanelClone != null)
                {
                    buildPanelClone.SetActive(false);
                    buildPanelClosed = true;
                    printScript.isBuildButtonPressed = false;//重置成没按Build
                }
            }
            //关掉BuildPanelOverlay
            if (!buildOverlayPanelClosed)
            {
                buildOverlayPanel.SetActive(false);
                buildOverlayPanelClosed = true;//关了就不要每帧设置成false
                printScript.isBuildButtonPressed = false;//重置成没按Build
                Debug.Log("closed");
            }
        }
        else
        {
            hasSpawnedObjects = false;
            buildPanelClosed = false;
            buildOverlayPanelClosed = false;
        }
    }

    
    //检查鱼的随机移动
    private void CheckRandomMovement()
    {
        if (creatureSpawn.spawnedCreature != null)
        {
            RandomMovement randomMovement = creatureSpawn.spawnedCreature.GetComponent<RandomMovement>();
            SpriteRenderer spriteRenderer = creatureSpawn.spawnedCreature.GetComponent<SpriteRenderer>();
            // Vector3 scale = spriteRenderer.transform.localScale;
            if (!creatureSpawn.randomMovementEnabled) 
            {
                if (randomMovement != null && spriteProgress.currentFill >= 1.5f)
                {
                    randomMovement.enabled = true;
                    creatureSpawn.randomMovementEnabled = true; 
                    spriteRenderer.maskInteraction = SpriteMaskInteraction.None;                  

                }
                else
                {
                    randomMovement.enabled = false;
                    spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                }

            }

        }

    }

    //检查ColorArch身上的重力
    private void CheckRigidBody()
    {
        if (archSpawn.spawnedArch != null)
        {
            Rigidbody2D rigidBody = archSpawn.spawnedArch.GetComponent<Rigidbody2D>();

            Transform[] children = archSpawn.spawnedArch.GetComponentsInChildren<Transform>();// 获取所有子对象

            if (!archSpawn.rigidBodyEnabled)
            {
                if (rigidBody != null && spriteProgress.currentFill >= 1.5f)
                {
                    // 启用重力
                    rigidBody.gravityScale = 1f;        
                    archSpawn.rigidBodyEnabled = true;
                    //遮罩交互
                    foreach (Transform child in children)
                    {
                        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                        if (spriteRenderer != null)
                        {
                            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
                        }
                    }

                }
                else
                {
                    rigidBody.gravityScale = 0f; // 禁用重力

                    foreach (Transform child in children)
                    {
                        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                        if (spriteRenderer != null)
                        {
                            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                        }
                    }
                }
            }

        }
    }

}
