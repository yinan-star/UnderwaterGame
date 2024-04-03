using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildPanel : MonoBehaviour
{
    public GameObject buildPanel;
    private void Start()
    {
        Instantiate(buildPanel, this.transform);
    }
}
