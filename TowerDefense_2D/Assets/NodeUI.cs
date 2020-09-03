using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;
    public Button upgrButton;

    public Text upgradeCost;
    public void SetTarget(Node _target)
    {
        this.target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.towerBlueprint.upgradeCost.ToString();
            upgrButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE_UP";
            upgrButton.interactable = false;

        }
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }
}
