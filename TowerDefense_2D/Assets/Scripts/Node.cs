using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
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

        if (!buildManager.CanBuild)
            return;

        if (tower != null)
        {
            Debug.Log("Нельзя строить");
            return;;
        }
        else
        {
            buildManager.BuildTowerOn(this);
        }
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

        sprRender.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sprRender.color = baseColor;
    }
}
