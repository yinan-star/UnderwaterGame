using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonEnd : MonoBehaviour
{
    public SpriteProgress spriteProgress;
    public GameObject currentUIPanel; // ��ǰ��ť����
    private RandomMovement randomMovement; // ������νű� 
    private const string printedObjectsTag = "printedObjects";// ͨ����ǩ���� spriteMask �Ľ�����ʽ

    void Start()
    {

        spriteProgress = GetComponent<SpriteProgress>();//��ȡ����Ϸ�������ϵ������ű�
       
        randomMovement = FindObjectOfType<RandomMovement>();//�ҹ��� randomMovement �ű�
       

    }

    void Update()
    {
        if (spriteProgress.currentFill >= 1.5f)
        {
            currentUIPanel.SetActive(false);//UI����

            if (randomMovement != null)//����ƶ�
            {
                randomMovement.enabled = true;
            }

            SetMaskInteraction(SpriteMaskInteraction.None);//SpriteMask�Ľ���
        }
        else
        {
            if (randomMovement != null)
            {
                randomMovement.enabled = false;           
            }

            SetMaskInteraction(SpriteMaskInteraction.VisibleInsideMask);
        }   
    }
    
    private void SetMaskInteraction(SpriteMaskInteraction interaction)
    {
        GameObject[] printedObjects = GameObject.FindGameObjectsWithTag(printedObjectsTag); //��ȡ���д��� printedObjects ��ǩ����Ϸ��������
        foreach (GameObject obj in printedObjects)
        {
            //��ȡ�� SpriteRenderer ���
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.maskInteraction = interaction;//������� interaction ����������Ϸ����� maskInteraction ����
            }

            // ��ȡ�� BoxCollider2D ���
            BoxCollider2D boxCollider = obj.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                // ���ݽ�����ʽ���� BoxCollider2D ������״̬
                if (interaction == SpriteMaskInteraction.None)
                {
                    boxCollider.enabled = true; 
                }
                else
                {
                    boxCollider.enabled = false; 
                }
            }
        }
    }
}
