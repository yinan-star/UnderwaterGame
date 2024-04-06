using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    float minSpeed; 
    [SerializeField]
    float maxSpeed; 
    [SerializeField]
    float range;

    GameObject bg;


    Vector2 wayPoint;
    Vector3 initialScale;

    void Start()
    {
        bg = GameObject.FindWithTag("Ground");
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
        Vector3 bgPosition = bg.transform.position;
        float bgWidth = bg.GetComponent<SpriteRenderer>().bounds.size.x;
        float bgHeight = bg.GetComponent<SpriteRenderer>().bounds.size.y;

        float bgLeft = bgPosition.x - bgWidth / 2f;//??????
        float bgRight = bgPosition.x + bgWidth / 2f;//??????
        float bgBottom = bgPosition.y - bgHeight / 2f;//??????
        float bgTop = bgPosition.y + bgHeight / 2f;//??
        wayPoint = new Vector2(Random.Range(bgLeft, bgRight), Random.Range(bgBottom, bgTop));
    }
   
}
