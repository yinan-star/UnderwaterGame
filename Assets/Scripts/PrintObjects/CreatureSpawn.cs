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
    private Vector3 worldPosition;

    private SpriteProgress spriteProgress;

    private bool positionSet = false;
    private bool isPressedCreartue = false;

    public static bool isSpawned;

    
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
    public void IsPressCreatureButton()
    {
        isPressedCreartue = true;
    }
    public void SpawnSelectedCreature()
    {      

        if (spawnCreatures != null && isPressedCreartue)//printoManager != null && 
        {
            //int selectedPrintoIndex = printoManager.selectedPrinto; // ��ȡѡ��Ĵ�ӡ���������
            int randomIndex = Random.Range(0, spawnCreatures.Length);
            GameObject selectedCreaturePrefab = spawnCreatures[randomIndex];// ������ֵ�������ҵ�ƥ���Prefab����
            if (selectedCreaturePrefab == null)
            {
                Debug.LogError("Selected creature prefab is null.");
                return;
            }          
            spawnedCreature = Instantiate(selectedCreaturePrefab, worldPosition, Quaternion.identity, transform);// ���ɸö���
            // 生成新生物后将 positionSet 重新设置为 false
            //生成的新物体调用身上的shake脚本
            isSpawned = true;
            
            positionSet = false;
            isPressedCreartue = false;
            randomMovementEnabled = false;
        }
  

    }

    
}
