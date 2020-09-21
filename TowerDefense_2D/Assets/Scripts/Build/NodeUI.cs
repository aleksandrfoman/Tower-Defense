using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;//Canvas UI tower
    private Node _target;//Tower select
    public Button upgrButton; //Button up
    public Text upgradeCost; //Cost up
    public Text sellAmount;
    public void SetTarget(Node _target)
    {
        this._target = _target;
        transform.position = this._target.GetBuildPosition();
        if (!this._target.isUpgraded)
        {
            upgradeCost.text = "UP $ " + this._target.towerBlueprint.upgradeCost.ToString();
            upgrButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE_UP";
            upgrButton.interactable = false;

        }

        sellAmount.text = "Sell $ " + this._target.towerBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Sell()
    {
        _target.SellTower();
        BuildManager.instance.DeselectNode();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }
}
