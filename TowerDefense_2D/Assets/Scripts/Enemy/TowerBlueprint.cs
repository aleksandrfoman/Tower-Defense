using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject prefab;
    public int cost;
    public GameObject upgradePrefab;
    public int upgradeCost;
    public string nameTower;

    public TowerBlueprint(GameObject prefab, int cost, GameObject upgradePrefab, int upgradeCost,string nameTower)
    {
        this.prefab = prefab;
        this.cost = cost;
        this.upgradePrefab = upgradePrefab;
        this.upgradeCost = upgradeCost;
        this.nameTower = nameTower;
    }
    public int GetSellAmount()
    {
        return cost / 2;
    }
}
