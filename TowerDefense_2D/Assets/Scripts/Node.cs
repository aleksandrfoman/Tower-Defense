using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;

    private GameObject turret;
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

        if (buildManager.GetTowerToBuild()==null)
            return;

        if (turret != null)
        {
            Debug.Log("Нельзя строить");
            return;;
        }
        else
        {
            GameObject turretToBuild = BuildManager.instance.GetTowerToBuild();
            turret = (GameObject) Instantiate(turretToBuild, transform.position, transform.rotation);
           // turret.transform.SetParent(gameObject.transform);
        }
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTowerToBuild() == null)
            return;

        sprRender.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sprRender.color = baseColor;
    }
}
