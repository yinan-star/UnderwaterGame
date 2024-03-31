using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    float minSpeed; // 最小速度
    [SerializeField]
    float maxSpeed; // 最大速度
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;
    

    Vector2 wayPoint;//随机路点
    Vector3 initialScale;//翻转用

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
