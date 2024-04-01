using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawn : MonoBehaviour
{
    public GameObject[] spawnCreatures;//�������
    private SelectPrintoManager printoManager;
    public GameObject spawnedCreature; 
    public bool randomMovementEnabled; // Ĭ�Ϲر� RandomMovement

    void Update()
    {
        printoManager = FindObjectOfType<SelectPrintoManager>();   
        
    }
    public void SpawnSelectedCreature()
    {      

        if (printoManager != null)
        {
            int selectedPrintoIndex = printoManager.selectedPrinto; // ��ȡѡ��Ĵ�ӡ���������
            GameObject selectedCreaturePrefab = spawnCreatures[selectedPrintoIndex];// ������ֵ�������ҵ�ƥ���Prefab����
            if (selectedCreaturePrefab == null)
            {
                Debug.LogError("Selected creature prefab is null.");
                return;
            }
            spawnedCreature = Instantiate(selectedCreaturePrefab, transform.position, Quaternion.identity);// ���ɸö���

            // ����Ĭ��״̬Ϊ�ر� RandomMovement
            randomMovementEnabled = false;
        }
  

    }

    
}
