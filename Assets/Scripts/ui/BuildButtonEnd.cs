using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonEnd : MonoBehaviour
{
    public SpriteProgress spriteProgress;
    public GameObject BuildPanel;  
    private Spawn spawnScript;
    private bool hasSpawnedObjects = false;
    public bool buildPanelClosed = false; 
    private Print printScript;
    private CreatureSpawn creatureSpawn;
    private ArchSpawn archSpawn;

    public GameObject shadowOfArch;

    //拿BuildPanel
    private UIInstantiateManager uIInstantiateManager;
    private GameObject buildPanelClone;

    void Start()
    {

        spriteProgress = GetComponent<SpriteProgress>();//��ȡ����Ϸ�������ϵ������ű�
        printScript = GetComponent<Print>();//��ȡPrint�ű�   
        spawnScript = FindObjectOfType<Spawn>();//��������Spwan�ű�
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
            if (!hasSpawnedObjects && spawnScript != null)//Instantiate垃圾
            {
                spawnScript.SpawnObjects();
                hasSpawnedObjects = true;
            }

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

        }
        else
        {
            hasSpawnedObjects = false;
            buildPanelClosed = false;
        }
    }
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
    private void CheckRigidBody()//检查arch身上的重力
    {
        if (archSpawn.spawnedArch != null)
        {
            Rigidbody2D rigidBody = archSpawn.spawnedArch.GetComponent<Rigidbody2D>();

            Transform[] children = archSpawn.spawnedArch.GetComponentsInChildren<Transform>();// 获取所有子对象

            if (!archSpawn.rigidBodyEnabled)
            {
                if (rigidBody != null && spriteProgress.currentFill >= 1.5f)
                {
                    rigidBody.gravityScale = 1f; // 启用重力
                    shadowOfArch.SetActive(false);//要替换成ShadowOfArchClone,Clone的那一个,关掉
                    archSpawn.rigidBodyEnabled = true;//要替换词Clone的ArchSpawn的刚体,打开.

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
