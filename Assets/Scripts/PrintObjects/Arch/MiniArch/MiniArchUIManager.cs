using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniArchUIManager : MonoBehaviour
{
    private ArchPointManager archPointManager;//调activeArchPointButtonsList
    public GameObject buildOverlayManager;//调打开BuildPanel组件
    private List<GameObject> activeArchPointButtonList;
    public Button archButton;
    private bool isArchPointListZero = false;
    public static bool isArchButtonPressed = false;

    void Start()
    {
        activeArchPointButtonList = new List<GameObject>();
        isArchPointListZero = false;
        isArchButtonPressed = false;
    }

    void Update()
    {
        if (SelectionUIPopUpManager.isOpenSelectionUI && archButton.enabled)//如果SelectionUI是打开的并且archButton是被激活的,就检查一下
        {

            archPointManager = FindObjectOfType<ArchPointManager>();
            activeArchPointButtonList = archPointManager.activeArchPointButtons;
            if (activeArchPointButtonList.Count == 0)
            {
                isArchPointListZero = true;
            }
            else
            {
                isArchPointListZero = false;
            }
        }
    }
    public void SpawnMiniArch()
    {
        if (isArchPointListZero && isArchButtonPressed)//并且按钮是被激活的 && Print.isArchButtonPressed
        {
            MiniArchSpawn miniArchSpawn = GetComponent<MiniArchSpawn>();///调该对象身上的MiniSpawn脚本里的方法
            if (miniArchSpawn != null)
            {
                miniArchSpawn.SpawnSelectedMiniArch();
            }
            isArchButtonPressed = false;

            Debug.Log("Zero and Press, than Spawn");
        }

    }
    public void OpenBuildOverlayPanel()
    {
        if (isArchPointListZero)
        {
            buildOverlayManager.SetActive(true); 
        }

    }
    public void PressArchButton()
    {
        if(activeArchPointButtonList.Count == 0)//因为防止，之前按了Arch，就设置成了true。
        {
            isArchButtonPressed = true;//按了ArchButton之后，弹出BuildPanel并生成了MiniArch之后，把她重置为false.
            Debug.Log("PressArchButtonAlready");
        }
        
    }
}

