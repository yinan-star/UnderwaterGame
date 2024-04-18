using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShake : MonoBehaviour
{
    // 抖动的幅度
    public float shakeAmount;

    // 抖动的速度
    public float shakeSpeed;

    // 初始位置
    private Vector2 initialPosition;

    private CreatureSpawn creatureSpawn;
    private ArchSpawn archSpawn;

    void Start()
    {
        // 保存初始位置
        initialPosition = transform.position;
    }
    void Update()
    {
        if (CreatureSpawn.isSpawned)//如果生成了新物体,就调新物体身上的shake
        {
            creatureSpawn = FindObjectOfType<CreatureSpawn>();
            ShakeShake spawnedCreatureShakeShake = creatureSpawn.spawnedCreature.GetComponent<ShakeShake>();
            spawnedCreatureShakeShake.ShakeCreature();
        }
        if (ArchSpawn.isSpawned)//如果生成了新物体,就调新物体身上的shake
        {
            archSpawn = FindObjectOfType<ArchSpawn>();
            ShakeShake spawnedArchShakeShake = archSpawn.spawnedArch.GetComponent<ShakeShake>();
            spawnedArchShakeShake.ShakeArch();
        }
    }

    public void ShakeCreature()
    {
        // 计算Y轴的偏移量，通过Sin函数实现上下抖动
        float offsetY = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

        // 更新物体的位置，保持 X 轴不变，只更新 Y 轴
        transform.position = new Vector2(transform.position.x, offsetY);
    }
    public void ShakeArch()
    {
        // 计算Y轴的偏移量，通过Sin函数实现上下抖动
        float offsetY = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

        // 更新物体的位置，保持 X 轴不变，只更新 Y 轴
        transform.position = new Vector2(transform.position.x, transform.position.y + offsetY);
    }

}
