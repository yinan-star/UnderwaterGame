using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonEnd : MonoBehaviour
{
    public SpriteProgress spriteProgress;
    public GameObject BuildPanel; // ��ǰ��ť����   
    private Spawn spawnScript;
    private bool hasSpawnedObjects = false;
    public bool buildPanelClosed = false; // ��־�Ƿ��Ѿ��ر��� BuildPanel
    private Print printScript;
    private CreatureSpawn creatureSpawn;
    private ArchSpawn archSpawn;

    void Start()
    {

        spriteProgress = GetComponent<SpriteProgress>();//��ȡ����Ϸ�������ϵ������ű�
        printScript = GetComponent<Print>();//��ȡPrint�ű�   
        spawnScript = FindObjectOfType<Spawn>();//��������Spwan�ű�
        creatureSpawn = FindObjectOfType<CreatureSpawn>();
        archSpawn = FindObjectOfType<ArchSpawn>();



    }

    private void Update()
    {
        CheckRandomMovement();
        CheckRigidBody();
        if (spriteProgress.currentFill >= 1.5f)
        {
            if (!hasSpawnedObjects && spawnScript != null)
            {
                spawnScript.SpawnObjects();// �������������ķ���
                hasSpawnedObjects = true; // ���������    
            }

            if (!buildPanelClosed)
            {
                // �ر� UI ����
                BuildPanel.SetActive(false);
                buildPanelClosed = true; // ���ص�BuildPanelʱ����ѹر�
                printScript.isBuildButtonPressed = false;//�ر�BuildPanel��ʱ������Build��ť״̬
            }

        }
        else
        {
            hasSpawnedObjects = false; // ���û����  
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
            if (!creatureSpawn.randomMovementEnabled) // ֻ�е�RandomMovementδ������ʱ��ִ�����´���
            {
                if (randomMovement != null && spriteProgress.currentFill >= 1.5f)
                {
                    randomMovement.enabled = true;
                    creatureSpawn.randomMovementEnabled = true; // ���RandomMovement�ѱ�����
                    spriteRenderer.maskInteraction = SpriteMaskInteraction.None;//SpriteMask�Ľ���                   

                }
                else
                {
                    randomMovement.enabled = false;
                    spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;//SpriteMask�Ľ���
                }

            }

        }

    }
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
                    rigidBody.gravityScale = 1f; // 启用重力
                    archSpawn.rigidBodyEnabled = true;

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
