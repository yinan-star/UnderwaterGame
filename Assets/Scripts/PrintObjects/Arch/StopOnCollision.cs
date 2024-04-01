using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{
    // ��������ײʱ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �����봥�����Ķ����Ƿ��ǵ���
        if (other.gameObject.CompareTag("Ground"))
        {
            // ����ǵ��棬ֹͣ������˶�
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // ���ٶ�����Ϊ��
                //rb.angularVelocity = 0f; // �����ٶ�����Ϊ�㣨�����Ҫ��
                rb.bodyType = RigidbodyType2D.Static; // ��������������ΪStatic��ʹ��ֹͣ�˶�
            }
        }
    }

}
