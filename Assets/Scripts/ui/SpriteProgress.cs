using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteProgress : MonoBehaviour
{
    private Print build;

    [SerializeField]
    private BuildCircle buildCircle;

    public float currentFill;
    
    void Start()
    {
        build = GetComponent<Print>();
    }


    void Update()
    {
        if (build != null)
        {
            float progress = build.GetAnimationProgress();
            if (progress >= 2f)
            {
                currentFill = 2f;
            }
            else
            {               
                currentFill = progress;
            }
            // ����ǰ�����Ľ��ȸ�ֵ�� currentFill�����ڸ��½�����             
            buildCircle.Fill(currentFill);
        }
    }
}
