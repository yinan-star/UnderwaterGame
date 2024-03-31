using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteProgress : MonoBehaviour
{
    private Print build;
    //private CreatureButtonClick buttonClick;

    [SerializeField]
    private BuildCircle buildCircle;

    public float currentFill;
    //private bool isCreatrueButtonClicked = false; // ���水ť�Ƿ񱻵����״̬
    void Start()
    {
        build = GetComponent<Print>();
        //buttonClick = FindObjectOfType<CreatureButtonClick>(); // ��ȡ CreatureButtonClick ���
    
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

    // ���ð�ť�������״̬
    //public void SetButtonClicked()
    //{
    //    isCreatrueButtonClicked = true;
    //}

}
