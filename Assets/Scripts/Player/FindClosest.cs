using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    private bool pickUpAllowed = false;

    public float destroyDistanceThreshold; // 设置销毁的距离阈值
    private PickUp closest;
    public int debrisCount;

    [SerializeField]
    private PickUp[] pickups; // 将 PickUp 数组定义为 SerializeField

    public ParticleSystem garbageParticles;
    void Update()
    {
        FindClosestObject();
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.N))
        {
            if (DialogueManager.isActive == true)
            {
                return;
            }
            Pickup();

        }

    }

    //�ҵ����������
    void FindClosestObject()
    {
        float distanceToClosest = Mathf.Infinity;//��������ľ����Ƿ�Χ�ٽ�ֵ
        closest = null;//���軹û�����������
        pickups = GameObject.FindObjectsOfType<PickUp>();//查找所有的垃圾对象
        foreach (PickUp p in pickups)
        {
            float distance = (p.transform.position - this.transform.position).sqrMagnitude;
            if (distance < distanceToClosest)
            {
                distanceToClosest = distance;
                closest = p;
            }
        }
        // return closest;
        if (closest != null)
        {
            // Debug.DrawLine(this.transform.position, closest.transform.position);
            pickUpAllowed = true;
        }
    }

    //ʰȡ����
    private void Pickup()
    {
        if (closest != null)
        {
            float distanceToClosest = Vector3.Distance(this.transform.position, closest.transform.position);//最近的垃圾和玩家的距离
            if (distanceToClosest < destroyDistanceThreshold)//如果小于阈值
            {
                //销毁最近的物体
                Destroy(closest.gameObject);
                //生成粒子效果
                Instantiate(garbageParticles, closest.gameObject.transform.position, Quaternion.identity);
                pickUpAllowed = false; // ʰȡ��ǵ�����ʰȡ����״̬��������
                //增加垃圾计数
                PickupItem();
            }


        }
    }


    //����ʰȡ���������
    public void PickupItem()
    {
        debrisCount++;
        //Debug.Log("Debris Count: " + debrisCount);
    }
}
