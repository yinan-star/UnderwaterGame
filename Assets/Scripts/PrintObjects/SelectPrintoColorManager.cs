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
            int selectedPrintoColor = selectPrintoManager.selectedPrinto;//从剪影那里获得索引值给要打印出来的物体
            UpdatePrintoColor(selectedPrintoColor);
        }
       
    }

    private void UpdatePrintoColor(int selectedPrintoColor)
    {
        PrintedColorObjects printedColorObjects = printoColorData.GetPrintoColor(selectedPrintoColor);
        selectedColorSprite.sprite = printedColorObjects.printedColorSprite;//从database里获取被选择物体的信息
    }
}
