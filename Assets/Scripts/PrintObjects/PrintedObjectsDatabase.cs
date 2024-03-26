using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PrintedObjectsDatabase : ScriptableObject
{
    public PrintedObjects[] printo;
    public int PrintoCount
    {
        get
        {
            return printo.Length;
        }
    }
    public PrintedObjects GetPrinto(int index)
    {
        return printo[index];
    }

}
