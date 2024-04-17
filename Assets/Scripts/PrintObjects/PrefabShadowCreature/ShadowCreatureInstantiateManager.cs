using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCreatureInstantiateManager : MonoBehaviour
{
    [SerializeField] private GameObject shadowCreatures;//要生成的原物体
    public GameObject shadowCreatureClone;//在别的脚本里要调新生成的
    public RectTransform BuildPanelOverlayPosition;
    public Camera mainCamera; // 主摄像机
    //拿生成的鱼身上的selectPrintoManager组件,因为鱼是动态生成的,所以直接拿这个脚本的鱼
    private SelectPrintoManager selectPrintoManager;


    private Vector3 cameraPosition;
    private Quaternion cameraRotation;
    public Vector3 worldPosition;

    public void SpawnShadowWithBuildPanel()
    {
        // 生成物体
        shadowCreatureClone = Instantiate(shadowCreatures, worldPosition, Quaternion.identity, transform);
    }

    void Update()
    {
        // 获取摄像机的位置和朝向
        cameraPosition = mainCamera.transform.position;
        cameraRotation = mainCamera.transform.rotation;
        // 调整生成点的位置
        float distanceFromCamera = 5f; // 生成点距离摄像机的距离

        worldPosition = cameraPosition + cameraRotation * Vector3.forward * distanceFromCamera;

        if (shadowCreatureClone != null)
        {
            // 更新物体的位置为主摄像机的位置并使之更加平滑
            shadowCreatureClone.transform.position = Vector3.Lerp(shadowCreatureClone.transform.position, worldPosition, Time.deltaTime * 5f);
        }
    }

    public void AddNextButtonEvent()
    {
        // 获取 ShadowArchManager 组件
        selectPrintoManager = FindObjectOfType<SelectPrintoManager>();
        if (selectPrintoManager != null)
        {
            selectPrintoManager.NextPrinto();
        }
    }
    public void AddPrevButtonEvent()
    {
        selectPrintoManager = FindObjectOfType<SelectPrintoManager>();
        if (selectPrintoManager != null)
        {
            selectPrintoManager.PreviousPrinto();
        }
    }

    public void CloseShadowCreature()
    {
        if (shadowCreatureClone != null)
        {
            // shadowCreatureClone.SetActive(false);
            Destroy(shadowCreatureClone);
        }

    }

}
