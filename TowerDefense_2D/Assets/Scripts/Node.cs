using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    private SpriteRenderer sprRender;

    private BuildManager buildManager;

    private void Awake()
    {
        sprRender = GetComponent<SpriteRenderer>();
        sprRender.color = baseColor;
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
            return;;
        }
        if (!buildManager.CanBuild)
            return;

        BuildTower(buildManager.GetTowerToBuild());
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Нет денег");
        }
        else
        {
            PlayerStats.Money -= blueprint.cost;
            GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
            towerBlueprint = blueprint;
            tower = _tower;
            Debug.Log("Постройка башни");
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
            Debug.Log("Нет денег на ап");
        }
        else
        {
            PlayerStats.Money -= towerBlueprint.upgradeCost;

            Destroy(tower);
            //Построить новую башню

            GameObject _tower = (GameObject)Instantiate(towerBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);

            tower = _tower;
            isUpgraded = true;
            Debug.Log("Апргейд успешен");
        }
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            sprRender.color = hoverColor;
        }
        else
        {
            sprRender.color = notMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        sprRender.color = baseColor;
    }
}
