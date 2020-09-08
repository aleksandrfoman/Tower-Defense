using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Сингелтон для строительства
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Больше одного билд менеджера в сцене");
        }
        instance = this;
    }

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

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;

    }
}
