using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notMoneyColor;
    public Color baseColor;

    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject tower;
    private SpriteRenderer sprRender;

    private BuildManager buildManager;

    private void Awake()
    {
        sprRender = GetComponent<SpriteRenderer>();
        sprRender.color = baseColor;
    }

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (tower != null)
        {
            buildManager.SelecetNode(this);
            return;;
        }
        else
        {
            buildManager.BuildTowerOn(this);
        }
        if (!buildManager.CanBuild)
            return;



    }

    public Vector3 GetBuildPosition()
    {
        return transform.position+positionOffset;
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            sprRender.color = hoverColor;
        }
        else
        {
            sprRender.color = notMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        sprRender.color = baseColor;
    }
}
