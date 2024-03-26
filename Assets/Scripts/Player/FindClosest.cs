using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    private bool pickUpAllowed = false;
    public float pickUpRange = 10.0f;//我咋感觉这个范围设不设都影响不大的？
    private PickUp closest;
    public int debrisCount;
    void Update()
    {
        FindClosestObject();
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Pickup();           
        }
                 
    }

    //找到最近的物体
    void FindClosestObject()
    {
        float distanceToClosest = pickUpRange;//假设最近的距离是范围临界值
        closest = null;//假设还没有最近的物体
        PickUp[] pickups = FindObjectsOfType<PickUp>();
        foreach (PickUp p in pickups)
        {
            float distance = Vector2.Distance(p.transform.position, transform.position);
            if(distance < distanceToClosest)
            {
                distanceToClosest = distance;
                closest = p;
            }
        }
        if (closest != null)
        {
            pickUpAllowed = true;
        }
    }

    //拾取物体
    private void Pickup()
    {
        if (closest != null)
        {
            Destroy(closest.gameObject);
            pickUpAllowed = false; // 拾取后记得重置拾取允许状态！！！！
            PickupItem();
        }
    }

    //计算拾取物体的数量
    public void PickupItem()
    {
        debrisCount++;
        //Debug.Log("Debris Count: " + debrisCount);
    }
}
