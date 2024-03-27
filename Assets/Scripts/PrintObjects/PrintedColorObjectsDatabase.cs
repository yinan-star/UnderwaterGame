using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PrintedColorObjectsDatabase : ScriptableObject
{
    public PrintedColorObjects[] printoColor;
    public int PrintoColorCount
    {
        get
        {
            return printoColor.Length;
        }
    }
    public PrintedColorObjects GetPrintoColor(int index)
    {
        return printoColor[index];
    }
}
