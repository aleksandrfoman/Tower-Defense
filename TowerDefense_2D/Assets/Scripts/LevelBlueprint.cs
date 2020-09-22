using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlueprint
{
    public GameObject prefab;
    public string indexName;

    public LevelBlueprint(GameObject prefab, string indexName)
    {
        this.prefab = prefab;
        this.indexName = indexName;
    }
}
