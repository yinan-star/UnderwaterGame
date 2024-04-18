using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShake : MonoBehaviour
{
    // 抖动的幅度
    public float shakeAmount = 0.03f;

    // 抖动的速度
    public float shakeSpeed = 70f;

    // 初始位置
    private Vector2 initialPosition;

    private CreatureSpawn creatureSpawn;

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
            spawnedCreatureShakeShake.Shake();
        }
    }

    public void Shake()
    {
        // 计算Y轴的偏移量，通过Sin函数实现上下抖动
        float offsetY = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

        // 更新物体的位置
        transform.position = initialPosition + new Vector2(0f, offsetY);

    }

}
