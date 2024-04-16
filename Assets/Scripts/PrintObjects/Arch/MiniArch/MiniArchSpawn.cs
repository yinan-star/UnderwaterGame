using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniArchSpawn : MonoBehaviour
{
    public GameObject[] spawnMiniArchs;//原物体
    public GameObject spawnedMiniArch;//已经生成的Arch
    public bool rigidBodyEnabled; //生成物体的时候他的rigidBody2D要默认是关的
    private ShadowCreatureInstantiateManager shadowCreatureInstantiateManager;//调摄像机更新的位置
    private Vector3 worldPosition;

    private SpriteProgress spriteProgress;

    private bool positionSet = false;

    private int initialSortingOrder;
    private bool isSavedOriginalOrder = false;
    private SpriteRenderer spriteRendererChild;
    private SpriteRenderer[] childrenSpriteRenderer;

    public string sortingLayerName = "Print"; // 指定的Sorting Layer 名称
    public int modifySortingOrder = 50; // 当spriteProgress.currentFill < 1.5 时的sortingOrder
    private void Start()
    {
        spriteProgress = FindObjectOfType<SpriteProgress>();
        isSavedOriginalOrder = false;

    }

    void Update()
    {
        shadowCreatureInstantiateManager = FindObjectOfType<ShadowCreatureInstantiateManager>();
        if (shadowCreatureInstantiateManager != null)
        {
            worldPosition = shadowCreatureInstantiateManager.worldPosition;

            if (spriteProgress.currentFill < 1.5)
            {
                if (!positionSet && spawnedMiniArch != null)
                {
                    // 更新物体的位置为主摄像机的位置
                    spawnedMiniArch.transform.position = Vector3.Lerp(spawnedMiniArch.transform.position, worldPosition, Time.deltaTime * 5f);                  
                }

                //如果存了最开始的层了后，在设置最顶
                if (isSavedOriginalOrder)
                {
                    foreach (SpriteRenderer childRenderer in childrenSpriteRenderer)//遍历子集的Sprite数组
                    {
                        spriteRendererChild = childRenderer.GetComponent<SpriteRenderer>();//获取每个子集身上的SpriteRenderer
                        spriteRendererChild.sortingOrder = modifySortingOrder;
                        isSavedOriginalOrder = false;
                    }        
                }
            }
            else
            {
                // 设回初始层
                if (spawnedMiniArch != null)
                {
                    if (spriteRendererChild != null)
                    {
                        foreach (SpriteRenderer childdRenderer in childrenSpriteRenderer)//遍历子集的Sprite数组
                        {
                            spriteRendererChild = childdRenderer.GetComponent<SpriteRenderer>();//获取每个子集身上的SpriteRenderer
                            spriteRendererChild.sortingOrder = initialSortingOrder;// 恢复初始的sortingOrder         
                        }

                    }
                }
                positionSet = true;
            }
        }

    }
    public void SpawnSelectedMiniArch()
    {

        if (spawnMiniArchs != null && spawnMiniArchs.Length > 0)
        {
            //生成数组里面的任意一个对象
            int randomIndex = Random.Range(0, spawnMiniArchs.Length);
            GameObject selectedMiniArch = spawnMiniArchs[randomIndex];
            spawnedMiniArch = Instantiate(selectedMiniArch, worldPosition, Quaternion.identity, transform);// ���ɸö���

            if(!isSavedOriginalOrder)
            {
                // 获取初始的sortingOrder
                childrenSpriteRenderer = spawnedMiniArch.GetComponentsInChildren<SpriteRenderer>();
                                                 
                foreach (SpriteRenderer childSpriteRenderer in childrenSpriteRenderer)
                {
                    spriteRendererChild = childSpriteRenderer.GetComponent<SpriteRenderer>();//每个子集身上的SpriteRenderer
                    if (spriteRendererChild != null)
                    {
                        initialSortingOrder = spriteRendererChild.sortingOrder;
                        
                    }
                    isSavedOriginalOrder = true;
                }
               
               
            }
           
            // 生成新生物后将 positionSet 重新设置为 false
            positionSet = false;
            rigidBodyEnabled = false;
        }


    }




}
