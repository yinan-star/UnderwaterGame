using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGarbageParticles : MonoBehaviour
{
    //生成物体后,震动摄像机并过几秒销毁Clone
    public float time;
    // Start is called before the first frame update
    public bool shakeCamera = true;
    void Start()
    {
        if (shakeCamera)
        {
            StartCoroutine(FindObjectOfType<CameraShake>().Shake(2f, 10.0f));
            Debug.Log("shake already");
        }

        Destroy(gameObject, time);

    }


}