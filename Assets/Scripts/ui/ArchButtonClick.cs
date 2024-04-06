using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArchButtonClick : MonoBehaviour
{
    public GameObject selectionUI;
    
 
   
    public void CloseSelectionUI()//关掉选择界面
    {
        selectionUI.SetActive(false);

    }
  
}
