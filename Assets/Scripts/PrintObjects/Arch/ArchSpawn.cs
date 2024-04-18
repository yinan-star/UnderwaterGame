using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchSpawn : MonoBehaviour
{
    public GameObject[] spawnArchs; //彩打建筑的组
    private ShadowArchManager shadowArchManager; // 获取Arch当前所选择的Arch的信息
    public GameObject spawnedArch; //存当前Instantiate的建筑,在别的脚本里掉
    public bool rigidBodyEnabled; //生成物体的时候他的rigidBody2D要默认是关的

    //拿新生成的ShadowArchs身上的Transfrom组件
    private ShadowInstantiatManager shadowInstantiatManager;
    private Transform shadowArchsTransform;

    public static bool isSpawned;


    private void Start()
    {
        shadowInstantiatManager = FindObjectOfType<ShadowInstantiatManager>();
    }

    public void SpawnSelectedArch()
    {
        shadowArchManager = FindObjectOfType<ShadowArchManager>();
        if (shadowArchManager != null)
        {
            int selectedArchIndex = shadowArchManager.selectedArch;
            GameObject selectedArchPrefab = spawnArchs[selectedArchIndex];

            //这个位置应该是新生成的shadowArchClone的位置
            if (shadowInstantiatManager != null)
            {
                GameObject shadowArchsClone = shadowInstantiatManager.shadowArchsClone;
                if (shadowArchsClone != null)
                {
                    shadowArchsTransform = shadowArchsClone.transform;
                    spawnedArch = Instantiate(selectedArchPrefab, shadowArchsTransform.position, Quaternion.identity, transform);
                    rigidBodyEnabled = false;
                    //生成的新物体调用身上的shake脚本
                    isSpawned = true;//生成了,可以shake                 
                }

            }

        }
        else
        {
            Debug.Log("shadowArchManager == null");
        }


    }
}
