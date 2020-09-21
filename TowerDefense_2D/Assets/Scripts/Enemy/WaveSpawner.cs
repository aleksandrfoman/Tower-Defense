using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0; //Сколько врагов живо

    public Wave[] waves; //Волны

    public Transform spawnPoint; //Точка спавна

    public float timeBetweenWaves = 5f; //Время между волной

    public float countdown = 2f; //Время между волнами


    private int waveIndex; //Индекс волны
    public int startWaveIndex = 0; //Начальный индекс волны

    private GameMenuScript gms;

    private void Start()
    {
        gms = FindObjectOfType<GameMenuScript>();
        EnemiesAlive = 0;
        waveIndex = startWaveIndex;
    }

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            gms.CheckGame(false);
            this.enabled = false;
        }
        else if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            //return;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        EnemiesAlive = wave.count;
        PlayerStats.Rounds++;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return  new WaitForSeconds(wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
    }
}
