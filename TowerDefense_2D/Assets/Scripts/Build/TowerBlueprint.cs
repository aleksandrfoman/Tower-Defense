using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject prefab; //Префаб вышки
    public int cost; //Стоимость вышки
    public GameObject upgradePrefab; //Префаб для апгрейда вышки
    public int upgradeCost; //Стоимость апгрейда

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
