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

    private TowerBlueprint towerToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;
    public bool CanBuild
    {
        get { return towerToBuild != null; }
    }
    public bool HasMoney
    {
        get { return PlayerStats.Money>=towerToBuild.cost; }
    }

    public void BuildTowerOn(Node node)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Нет денег");
        }
        else
        {
            PlayerStats.Money -= towerToBuild.cost;
            GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.tower = tower;
            Debug.Log(("Вышка построена , деньги: " + PlayerStats.Money));
        }
    }

    public void SelecetNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        towerToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        DeselectNode();
    }
}
