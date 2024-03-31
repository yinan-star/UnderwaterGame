using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ArchDatabase : ScriptableObject
{
    public Arch[] arch;
    public int ArchCount
    {
        get
        {
            return arch.Length;
        }
    }
    public Arch GetArch(int index)
    {
        return arch[index];
    }
}
