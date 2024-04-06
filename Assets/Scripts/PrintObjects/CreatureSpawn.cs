using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawn : MonoBehaviour
{
    public GameObject[] spawnCreatures;//�������
    private SelectPrintoManager printoManager;
    public GameObject spawnedCreature; 
    public bool randomMovementEnabled; // Ĭ�Ϲر� RandomMovement
    private ShadowCreatureInstantiateManager shadowCreatureInstantiateManager;
    //private GameObject shadowCreatureClone;
    private Vector3 worldPosition;

    private SpriteProgress spriteProgress;

    private bool positionSet = false;
    private void Start()
    {
        spriteProgress = FindObjectOfType<SpriteProgress>();
    }

    void Update()
    {
        printoManager = FindObjectOfType<SelectPrintoManager>();
        shadowCreatureInstantiateManager = FindObjectOfType<ShadowCreatureInstantiateManager>();
        if (shadowCreatureInstantiateManager != null)
        {
            worldPosition = shadowCreatureInstantiateManager.worldPosition;

            if(spriteProgress.currentFill < 1.5)
            {
                if(!positionSet && spawnedCreature != null)
                {
                    // 更新物体的位置为主摄像机的位置
                    spawnedCreature.transform.position = Vector3.Lerp(spawnedCreature.transform.position, worldPosition, Time.deltaTime * 5f);

                }
            }
            else
            {
                positionSet = true;
            }   
        }
     
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
            spawnedCreature = Instantiate(selectedCreaturePrefab, worldPosition, Quaternion.identity);// ���ɸö���
            // 生成新生物后将 positionSet 重新设置为 false
            positionSet = false;
        
            randomMovementEnabled = false;
        }
  

    }

    
}
