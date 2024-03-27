using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPrintoManager : MonoBehaviour
{
    public PrintedObjectsDatabase printoData;
    public SpriteRenderer selectedSprite;

    public int selectedPrinto = 0;

    private void Start()
    {
        UpdatePrinto(selectedPrinto);
    }
    public void NextPrinto()
    {
        selectedPrinto = (selectedPrinto + 1) % printoData.PrintoCount;//取余，达到数组的长度时重新回到 0
        UpdatePrinto(selectedPrinto);
    }
   
    public void PreviousPrinto()
    {
        selectedPrinto--;
        if (selectedPrinto < 0)
        {
            selectedPrinto = printoData.PrintoCount - 1;
        }
        UpdatePrinto(selectedPrinto);
    }
    private void UpdatePrinto(int selectedPrinto)
    {
        PrintedObjects printedObjects = printoData.GetPrinto(selectedPrinto);
        selectedSprite.sprite = printedObjects.printedSprite;//从database里获取被选择物体的信息
    }
}
