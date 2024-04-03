using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInstantiateManager : MonoBehaviour
{
    [SerializeField] private GameObject buildPanel;
    public GameObject buildPanelClone;

    private void Start()
    {
        buildPanelClone = Instantiate(buildPanel, this.transform);
    }
}
