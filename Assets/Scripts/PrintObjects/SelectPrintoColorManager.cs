using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPrintoColorManager : MonoBehaviour
{
    public PrintedColorObjectsDatabase printoColorData;
    public SpriteRenderer selectedColorSprite;
    private SelectPrintoManager selectPrintoManager;

    private void Update()
    {
        selectPrintoManager = FindObjectOfType<SelectPrintoManager>();
        if (selectPrintoManager != null)
        {
            int selectedPrintoColor = selectPrintoManager.selectedPrinto;//�Ӽ�Ӱ����������ֵ��Ҫ��ӡ����������
            UpdatePrintoColor(selectedPrintoColor);
        }
       
    }

    private void UpdatePrintoColor(int selectedPrintoColor)
    {
        PrintedColorObjects printedColorObjects = printoColorData.GetPrintoColor(selectedPrintoColor);
        selectedColorSprite.sprite = printedColorObjects.printedColorSprite;//��database���ȡ��ѡ���������Ϣ
    }
}
