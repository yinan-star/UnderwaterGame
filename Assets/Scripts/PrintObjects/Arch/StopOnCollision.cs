using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{
    // 当发生碰撞时调用
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查进入触发器的对象是否是地面
        if (other.gameObject.CompareTag("Ground"))
        {
            // 如果是地面，停止物体的运动
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // 将速度设置为零
                //rb.angularVelocity = 0f; // 将角速度设置为零（如果需要）
                rb.bodyType = RigidbodyType2D.Static; // 将刚体类型设置为Static，使其停止运动
            }
        }
    }

}
