using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public List<GameObject> spawnObjects;
    private List<GameObject> initialSpawnObjects;
    public GameObject bg;
    private SelectionUIPopUpManager selectionUIPopUpManager;
    public GameObject resetButton;
    public static bool isEndedAll = false;


    void Start()
    {
        selectionUIPopUpManager = FindObjectOfType<SelectionUIPopUpManager>();
        initialSpawnObjects = new List<GameObject>(spawnObjects); // 保存初始数量
        StartCoroutine(SpawnAndCheck());
        resetButton.SetActive(false);


    }
    void Update()
    {
        HasGarbage();
        if(isEndedAll && spawnObjects.Count == 0)
        {
            resetButton.SetActive(true);
        }

    }

    public IEnumerator SpawnAndCheck()
    {
        SpawnObjects();

        // 如果 spawnObjects 为空不执行
        if (spawnObjects.Count == 0)
        {
            ActiveEndingDialogue();
            
            yield break;
        }

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

    //判断场景有无垃圾
    private bool HasGarbage()
    {
        PickUp[] pickUps = FindObjectsOfType<PickUp>();//看场景里有无挂PickUp脚本的垃圾。因为我在particleEffect对应是用了Garbage标签
        return pickUps.Length > 0;
    }

    // 减少 spawnObjects 数组长度的方法
    public void ReduceSpawnNumber()
    {
        // 如果 spawnObjects 数组长度大于 0，则移除第一个元素
        if (spawnObjects.Count > 0)
        {
            spawnObjects.RemoveAt(0); // 移除列表的第一个元素
            StartCoroutine(SpawnAndCheck());//生成新的物体并检查Ui
        }
    }

    //弹出对话，询问是否继续，还没调...
    public void SpawnAgain()
    {
        spawnObjects = new List<GameObject>(initialSpawnObjects);//初始存的Objects添加给spawnObjects
        StartCoroutine(SpawnAndCheck()); // 生成新的物体并检查 UI
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

    public void ActiveEndingDialogue()
    {

        GameObject endingDialogueTrigger = GameObject.FindGameObjectWithTag("Ending");
        if (endingDialogueTrigger != null)
        {
            DialogueTrigger endingDialogue = endingDialogueTrigger.GetComponent<DialogueTrigger>();
            if (endingDialogue != null)
            {
                endingDialogue.StartDialogue();
            }
        }
    }
}
