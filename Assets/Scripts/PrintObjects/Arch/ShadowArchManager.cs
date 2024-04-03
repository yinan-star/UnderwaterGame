using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowArchManager : MonoBehaviour
{
    public ArchDatabase archData;
    public SpriteRenderer selectedArchSprite;

    public int selectedArch = 0;

    private void Start()
    {
        UpdatePrinto(selectedArch);
    }
    public void NextPrinto()
    {
        selectedArch = (selectedArch + 1) % archData.ArchCount;
        UpdatePrinto(selectedArch);
    }

    public void PreviousPrinto()
    {
        selectedArch--;
        if (selectedArch < 0)
        {
            selectedArch = archData.ArchCount - 1;
        }
        UpdatePrinto(selectedArch);
    }
    private void UpdatePrinto(int selectedArch)
    {
        Arch arch = archData.GetArch(selectedArch);
        selectedArchSprite.sprite = arch.archSprite;
    }
}
