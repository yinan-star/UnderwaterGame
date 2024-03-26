using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCircle : MonoBehaviour
{
    public Image fillCircle;

    public void Fill(float fillPoints)
    {
        fillCircle.fillAmount = fillPoints;
    }
}
