using UnityEngine;
using UnityEngine.UI;

public class NodeUI
{
    public GameObject _ui;//Canvas UI tower
    private Node _target;//Tower select
    public Button _upgrButton; //Button up
    public Button _sellButton; //Button up
    public Text _upgrCost; //Cost up
    public Text _sellAmount;

    public void Init()
    {
        _ui = GameObject.Find("uiCanvas");
        _upgrButton = GameObject.Find("UpgradeButton").GetComponent<Button>();
        _upgrCost = _upgrButton.transform.Find("TextUpgrade").GetComponent<Text>();
        _sellButton = GameObject.Find("SellButton").GetComponent<Button>();
        _sellAmount = _sellButton.transform.Find("TextSell").GetComponent<Text>();
        Hide();
    }
    public void SetTarget(Node _target)
    {
        this._target = _target;
        _ui.transform.position = this._target.GetBuildPosition()+new Vector3(0,2);
        if (!this._target.isUpgraded)
        {
            _upgrCost.text = "UP $ " + this._target.towerBlueprint.upgradeCost.ToString();
            _upgrButton.interactable = true;
        }
        else
        {
            _upgrCost.text = "DONE_UP";
            _upgrButton.interactable = false;

        }

        _sellAmount.text = "Sell $ " + this._target.towerBlueprint.GetSellAmount();

        _ui.SetActive(true);
    }

    public void Sell()
    {
        _target.SellTower();
        BuildManager.instance.DeselectNode();
    }

    public void Hide()
    {
        _ui.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }
}
