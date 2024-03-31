using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawn : MonoBehaviour
{
    public GameObject[] spawnCreatures;//鱼的数组
    private SelectPrintoManager printoManager;
    public GameObject spawnedCreature;
    public bool randomMovementEnabled; // 默认关闭 RandomMovement

    void Update()
    {
        printoManager = FindObjectOfType<SelectPrintoManager>();   
        
    }
    public void SpawnSelectedCreature()
    {      

        if (printoManager != null)
        {
            int selectedPrintoIndex = printoManager.selectedPrinto; // 获取选择的打印物体的索引
            GameObject selectedCreaturePrefab = spawnCreatures[selectedPrintoIndex];// 把索引值给数组找到匹配的Prefab对象
            if (selectedCreaturePrefab == null)
            {
                Debug.LogError("Selected creature prefab is null.");
                return;
            }
            spawnedCreature = Instantiate(selectedCreaturePrefab, transform.position, Quaternion.identity);// 生成该对象

            // 设置默认状态为关闭 RandomMovement
            randomMovementEnabled = false;
        }
  

    }

    
}
