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
    private void Start()
    {
        spriteProgress = FindObjectOfType<SpriteProgress>();
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
            }
            else
            {
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
            spawnedMiniArch = Instantiate(selectedMiniArch, worldPosition, Quaternion.identity);// ���ɸö���

            // 生成新生物后将 positionSet 重新设置为 false
            positionSet = false;
            rigidBodyEnabled = false;
        }


    }




}
