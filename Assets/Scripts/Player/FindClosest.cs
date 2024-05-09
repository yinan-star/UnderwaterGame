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
    private PickUp[] pickups; 
    private ParticlesSpawn particlesSpawnScript; // ParticlesSpawn 脚本的引用
    public Transform particleSpawnTrans;//存生成的特效的父物体

    public ParticleSystem garbageParticles;

    //调音乐
    AudioManager audioManager;
    private void Start()
    {       
        // 获取 ParticlesSpawn 脚本的引用
        particlesSpawnScript = FindObjectOfType<ParticlesSpawn>();
 
    }
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
                // 获取closest对象的标签
                string closestTag = closest.gameObject.tag;
                foreach(GameObject particle in particlesSpawnScript.spawnParticles)
                {
                    if(particle.CompareTag(closestTag))
                    {
                        //生成对应的粒子效果
                        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
                        audioManager.PlaySFX(audioManager.pickUp);
                        Instantiate(particle, closest.gameObject.transform.position, Quaternion.identity, particleSpawnTrans);
                    }
                }                                         
               
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
