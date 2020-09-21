using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notMoneyColor;
    public Color baseColor;

    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject tower;

    public TowerBlueprint towerBlueprint;

    public bool isUpgraded = false;

    private SpriteRenderer _sprRender; //Sprite Node
    public GameObject impactEffect; //Effects for build

    public Text[] notificationTexts; //NotificationO


    private BuildManager buildManager;

    private void Awake()
    {
        _sprRender = GetComponent<SpriteRenderer>();
        _sprRender.color = baseColor;
    }

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (tower != null)
        {
            buildManager.SelecetNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;

        BuildTower(buildManager.GetTowerToBuild());
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("NO MONEY");
        }
        else
        {
            PlayerStats.Money -= blueprint.cost;
            GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
            towerBlueprint = blueprint;
            tower = _tower;
            Instantiate(impactEffect, transform.position, transform.rotation);

        }
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position+positionOffset;
    }

    public void UpgradeTower()
    {
        if (PlayerStats.Money < towerBlueprint.upgradeCost)
        {
            Debug.Log("No money to upgrade");
        }
        else
        {
            PlayerStats.Money -= towerBlueprint.upgradeCost;

            Destroy(tower);

            GameObject _tower = (GameObject)Instantiate(towerBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);

            tower = _tower;
            isUpgraded = true;
            Debug.Log("Upgrade done");
        }
    }

    public void SellTower()
    {
        PlayerStats.Money += towerBlueprint.GetSellAmount();
        Destroy(tower);
        isUpgraded = false;
        towerBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            _sprRender.color = hoverColor;
        }
        else
        {
            _sprRender.color = notMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        _sprRender.color = baseColor;
    }
}
