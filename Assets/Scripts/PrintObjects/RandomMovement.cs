using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;

    Vector2 wayPoint;//Ëæ»úÂ·µã
    Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale; 
        SetNewDestination();
    }

   
    void Update()
    {
        //Move
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        // Flip
        if (transform.position.x < wayPoint.x)
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
