using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnObjects;
    //private Vector2 screenBounds;

    public GameObject bg;
    void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
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
        Vector3 bgPosition = bg.transform.position;
        float bgWidth = bg.GetComponent<SpriteRenderer>().bounds.size.x;
        float bgHeight = bg.GetComponent<SpriteRenderer>().bounds.size.y;

        float bgLeft = bgPosition.x - bgWidth / 2f;
        float bgRight = bgPosition.x + bgWidth / 2f;
        float bgBottom = bgPosition.y - bgHeight / 2f;
        float bgTop = bgPosition.y + bgHeight / 2f;
        // 生成随机位置
        return new Vector2(Random.Range(bgLeft, bgRight), Random.Range(bgPosition.y, bgTop));
    }
}
