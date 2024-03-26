using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue//靠DialogueTrigger展示在相关联的物体上。HealthBar
{
    public string name;
    [TextArea(3, 10)]//就是写的地方会大一点把
    public string[] sentences;
}
