using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
    public TowerBlueprint[] towers;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTower(int i)
    {
        buildManager.SelectTowerToBuild(towers[i]);
    }

}
