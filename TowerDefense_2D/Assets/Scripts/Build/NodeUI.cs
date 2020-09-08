using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;//Канвас UI вышки
    private Node target;//Какая вышка выбрана
    public Button upgrButton; //Кнопка апа
    public Text upgradeCost; //Цена  апа
    public Text sellAmount; //Цена продажи
    public void SetTarget(Node _target)
    {
        this.target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "UP $ " + target.towerBlueprint.upgradeCost.ToString();
            upgrButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE_UP";
            upgrButton.interactable = false;

        }

        sellAmount.text = "Sell $ " + target.towerBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectNode();
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
