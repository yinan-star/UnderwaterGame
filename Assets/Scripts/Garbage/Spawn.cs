using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> spawnObjects;
    public GameObject bg;
    private SelectionUIPopUpManager selectionUIPopUpManager;
    // private List<GameObject> garbageObjects;

    void Start()
    {
        // SpawnObjects();
        selectionUIPopUpManager = FindObjectOfType<SelectionUIPopUpManager>();
        StartCoroutine(SpawnAndCheck());
    }
    void Update(){
        HasGarbage();
    }

    public IEnumerator SpawnAndCheck()
    {
        SpawnObjects();

        // 等待场景中垃圾的数量为0
        while (HasGarbage())
        {
            yield return null;
        }

        // 当垃圾数量为0时，打开选择面板
        selectionUIPopUpManager.OpenSelectionPanel();
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

    //有垃圾
    private bool HasGarbage()
    {
        GameObject[] garbageObjects = GameObject.FindGameObjectsWithTag("Garbage");
        return garbageObjects.Length > 0;
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
