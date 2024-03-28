using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnObjects;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
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
            Instantiate(spawnObject, randomPosition, Quaternion.identity);
        }
    }
    Vector2 GetRandomPosition()
    {
        // 生成随机位置
        Vector2 randomPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
        return randomPosition;
    }
}
