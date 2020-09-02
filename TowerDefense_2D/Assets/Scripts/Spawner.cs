using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn = 4;
    private int spawnCount = 0;
    public GameObject enemyPref;

    private void Update()
    {
        if (timeToSpawn <= 0)
        {
            StartCoroutine(SpawnEnemy(spawnCount + 1));
            timeToSpawn = 4;
        }

        timeToSpawn -= Time.deltaTime;
    }

    IEnumerator SpawnEnemy(int enemyCount)
    {
        spawnCount++;
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject tmpEnemy = Instantiate(enemyPref);
            tmpEnemy.transform.SetParent(gameObject.transform,false);

            yield return new WaitForSeconds(0.4f);
        }
    }
}
