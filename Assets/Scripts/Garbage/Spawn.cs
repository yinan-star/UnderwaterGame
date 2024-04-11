using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> spawnObjects;

    public GameObject bg;
    void Start()
    {
        SpawnObjects();
    }

    void Update()
    {
        
    }
    public void SpawnObjects()
    {
        
        foreach (GameObject spawnObject in spawnObjects)
        {
            Vector2 randomPosition = GetRandomPosition();
            GameObject spawnedObject = Instantiate(spawnObject, randomPosition, Quaternion.identity);
            spawnedObject.transform.parent = transform; // 设置生成的对象的父级为当前对象
                 
        }
    }

    // 减少 spawnObjects 数组长度的方法
    public void ReduceSpawnNumber()
    {
        // 如果 spawnObjects 数组长度大于 0，则移除第一个元素
        if (spawnObjects.Count > 0) 
        {
            spawnObjects.RemoveAt(0); // 移除列表的第一个元素
        }
    }

    Vector2 GetRandomPosition()
    {
        Vector3 bgPosition = bg.transform.position;
        float bgWidth = bg.GetComponent<SpriteRenderer>().bounds.size.x;
        float bgHeight = bg.GetComponent<SpriteRenderer>().bounds.size.y;

        float bgLeft = bgPosition.x - bgWidth / 2f;
        float bgRight = bgPosition.x + bgWidth / 2f;
        float bgBottom = bgPosition.y - bgHeight / 2f;
        float bgTop = bgPosition.y + bgHeight / 2f;
        // �������λ��
        return new Vector2(Random.Range(bgLeft, bgRight), Random.Range(bgPosition.y, bgTop));
    }
}
