using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;

    private GameObject turret;
    private SpriteRenderer sprRender;

    private void Awake()
    {
        sprRender = GetComponent<SpriteRenderer>();
        sprRender.color = baseColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Нельзя строить");
            return;;
        }
        else
        {
            GameObject turretToBuild = BuildManager.instance.GetTuuretToBuild();
            turret = (GameObject) Instantiate(turretToBuild, transform.position, transform.rotation);
           // turret.transform.SetParent(gameObject.transform);
        }
    }

    private void OnMouseEnter()
    {
       sprRender.color = hoverColor;
    }

    private void OnMouseExit()
    {
       sprRender.color = baseColor;
    }
}
