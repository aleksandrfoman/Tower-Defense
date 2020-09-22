using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            Debug.Log("More one build manager");
        }
        instance = this;

    }

    private TowerBlueprint _towerToBuild;
    private Node _selectedNode;
    public NodeUI _nodeUi;

    private void Start()
    {
        _nodeUi = new NodeUI();
        _nodeUi.Init();
    }

    public bool CanBuild
    {
        get { return _towerToBuild != null; }
    }
    public bool HasMoney
    {
        get { return PlayerStats.Money>=_towerToBuild.cost; }
    }

    public void SelecetNode(Node node)
    {
        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }
        _selectedNode = node;
        _towerToBuild = null;

        _nodeUi.SetTarget(node);
    }

    public void DeselectNode()
    {
        _selectedNode = null;
        _nodeUi.Hide();
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        _towerToBuild = tower;
        DeselectNode();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return _towerToBuild;

    }
}
