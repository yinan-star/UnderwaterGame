using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowInstantiatManager : MonoBehaviour
{
    [SerializeField] private GameObject shadowArchs;//要生成的原物体
    public GameObject shadowArchsClone;//在别的脚本里要调新生成的
    public Transform[] transforms;

    private void Start()
    {
        shadowArchsClone = null;//假设他开始就是null
    }
    public void SpawnShadowArchsPoint01()
    {
        shadowArchsClone = Instantiate(shadowArchs, transforms[0].position, Quaternion.identity);//在transforms的第一个索引的位置生成新的Shadow.       

    }
    public void SpawnShadowArchsPoint02()
    {
        shadowArchsClone = Instantiate(shadowArchs, transforms[1].position, Quaternion.identity);//在transforms的第一个索引的位置生成新的Shadow.       

    }
    public void SpawnShadowArchsPoint03()
    {
        shadowArchsClone = Instantiate(shadowArchs, transforms[2].position, Quaternion.identity);//在transforms的第一个索引的位置生成新的Shadow.       

    }





}
