using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    private bool pickUpAllowed = false;
    public float pickUpRange = 10.0f;//��զ�о������Χ�費�趼Ӱ�첻��ģ�
    private PickUp closest;
    public int debrisCount;
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
        float distanceToClosest = pickUpRange;//��������ľ����Ƿ�Χ�ٽ�ֵ
        closest = null;//���軹û�����������
        PickUp[] pickups = FindObjectsOfType<PickUp>();
        foreach (PickUp p in pickups)
        {
            float distance = Vector2.Distance(p.transform.position, transform.position);
            if (distance < distanceToClosest)
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

    //ʰȡ����
    private void Pickup()
    {
        if (closest != null)
        {
            Destroy(closest.gameObject);
            pickUpAllowed = false; // ʰȡ��ǵ�����ʰȡ����״̬��������
            PickupItem();
        }
    }

    //����ʰȡ���������
    public void PickupItem()
    {
        debrisCount++;
        //Debug.Log("Debris Count: " + debrisCount);
    }
}
