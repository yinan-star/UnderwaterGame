using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    float minSpeed; // ��С�ٶ�
    [SerializeField]
    float maxSpeed; // ����ٶ�
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;
    

    Vector2 wayPoint;//���·��
    Vector3 initialScale;//��ת��

    void Start()
    {
        initialScale = transform.localScale;
        SetNewDestination();
       
    }

   
    void Update()
    {
        // RandomSpeed
        float currentSpeed = Random.Range(minSpeed, maxSpeed);
       
        //Move
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, currentSpeed * Time.deltaTime);

        // Flip
        if (transform.position.x > wayPoint.x)
            transform.localScale = initialScale;
        else
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);

        //NewDest
        if (Vector2.Distance(transform.position, wayPoint) < range)
            SetNewDestination();
    }
    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
   
}
