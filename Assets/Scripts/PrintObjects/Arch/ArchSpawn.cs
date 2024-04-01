using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchSpawn : MonoBehaviour
{
    public GameObject[] spawnArchs;//�������
    private ArchManager archManager; // 获取Arch当前所选择的Arch的信息
    public GameObject spawnedArch; //存当前Instantiate的建筑,在别的脚本里掉
    public bool rigidBodyEnabled; //生成物体的时候他的rigidBody2D要默认是关的


    void Update()
    {
        archManager = FindObjectOfType<ArchManager>();   
        
    }
    public void SpawnSelectedArch()
    {      

        if (archManager != null)
        {
            int selectedArchIndex = archManager.selectedArch; // ��ȡѡ��Ĵ�ӡ���������
            Debug.Log("selectedArch 的值是：" + selectedArchIndex);
            GameObject selectedArchPrefab = spawnArchs[selectedArchIndex];// ������ֵ�������ҵ�ƥ���Prefab����
            if (selectedArchPrefab == null)
            {
                Debug.LogError("Selected creature prefab is null.");
                return;
            }
            spawnedArch = Instantiate(selectedArchPrefab, selectedArchPrefab.transform.position, Quaternion.identity);// ���ɸö���

            rigidBodyEnabled = false;

        }

  

    }
}
