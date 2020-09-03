using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint stadnartTower;
    public TowerBlueprint antoherTower;
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTower()
    {
        buildManager.SelectTowerToBuild(stadnartTower);
    }

    public void SelectAnotherTower()
    {
        buildManager.SelectTowerToBuild(antoherTower);
    }

}
