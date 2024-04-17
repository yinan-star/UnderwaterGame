using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    //生成垃圾

    public List<GameObject> spawnObjects;
    private List<GameObject> initialSpawnObjects;
    public GameObject bg;
    private SelectionUIPopUpManager selectionUIPopUpManager;
    public GameObject resetButton;
    //public GameObject transition;
    public static bool isTageWithEnding = false;
    private static bool isActiveNearlyDialogue = false;

    void Start()
    {
        selectionUIPopUpManager = FindObjectOfType<SelectionUIPopUpManager>();
        initialSpawnObjects = new List<GameObject>(spawnObjects); // 保存初始数量
        StartCoroutine(SpawnAndCheck());
        resetButton.SetActive(false);  

        isTageWithEnding = false;
        isActiveNearlyDialogue = false;
    }
    void Update()
    {
        HasGarbage();

        if (spawnObjects.Count == 0 && isActiveNearlyDialogue)
        {
            StartCoroutine(ActivateEndingDialogueAfterDelay());//每帧判断当前弹窗是否关了，就激活最后的对白
        }
        if (isTageWithEnding)
        {
            StartCoroutine(ActivateResetButtonAfterDelay());//等几秒，判断最后的弹话是否关了，关了，就激活ResetButton.
        }

    }
    //等弹话结束,激活ResetButton
    IEnumerator ActivateResetButtonAfterDelay()
    {
        // 等待 2 秒钟,检查弹话状态。
        yield return new WaitForSeconds(2f);
        if(!DialogueManager.isActive)
        {
            // 激活 resetButton
            resetButton.SetActive(true);
        }
        else
        {
            resetButton.SetActive(false);
        }
       
    }

    //等Nearly弹话结束，激活Ending弹话
    IEnumerator ActivateEndingDialogueAfterDelay()
    {
        // 等待 2 秒钟,检查弹话状态。
        yield return new WaitForSeconds(2f);
        if (!DialogueManager.isActive)
        {
            // 激活最后的对白
            ActiveEndingDialogue();
        }

    }


    public IEnumerator SpawnAndCheck()
    {
        SpawnObjects();

        // 如果 spawnObjects 为空不执行
        if (spawnObjects.Count == 0)
        {
            ActiveNearlyEndingDialogue();//先马上激活这个
            //transition.SetActive(true);//激活这个游戏对象,它会自动播放动画.          
            //ActiveEndingDialogue();   //弹,等打开Transition动画结束后在弹.
           
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
  

    //生成垃圾
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

    // 生成垃圾的位置
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
        return new Vector2(Random.Range(bgLeft+5f, bgRight-5f), Random.Range(bgPosition.y, bgTop - 2f));
    }

    //激活EndingDialogue对话
    public void ActiveEndingDialogue()
    {
        if(!isTageWithEnding)
        {
            GameObject endingDialogueTrigger = GameObject.FindGameObjectWithTag("Ending");
            isTageWithEnding = true;//只激活一次
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
    //激活NearlyEndingDialogue
    public void ActiveNearlyEndingDialogue()
    {
        if(!isActiveNearlyDialogue)
        {
            GameObject nearlyEndingTrigger = GameObject.FindGameObjectWithTag("Nearly");
            isActiveNearlyDialogue = true;//只激活一次
            if (nearlyEndingTrigger != null)
            {
                DialogueTrigger nearlyEndingDialogue = nearlyEndingTrigger.GetComponent<DialogueTrigger>();
                if (nearlyEndingDialogue != null)
                {
                    nearlyEndingDialogue.StartDialogue();
                }
            }
        }
        
    }
}
