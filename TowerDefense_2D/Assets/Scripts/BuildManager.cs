using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Больше одного билд менеджера в сцене");
        }
        instance = this;
    }

    public GameObject standardTowerPrefab;
    public GameObject anotherTowerPrefab;

    private GameObject turretToBuild;


    public GameObject GetTowerToBuild()
    {
        return turretToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        turretToBuild = tower;
    }
}
