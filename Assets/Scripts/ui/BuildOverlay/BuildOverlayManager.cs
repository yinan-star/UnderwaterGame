using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOverlayManager : MonoBehaviour
{
    public GameObject buildOvelayPanel;
   
    public void OpenBuildOverlayPanel()
    {
        buildOvelayPanel.SetActive(true);
    }
    public void CloseBuildOverlayPanel()
    {
        buildOvelayPanel.SetActive(false);
    }
    
}
