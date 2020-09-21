using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public float countdown = 2f;


    private int _waveIndex;
    public int startWaveIndex = 0;

    private GameMenuScript _gms;

    private void Start()
    {
        _gms = FindObjectOfType<GameMenuScript>();
        EnemiesAlive = 0;
        _waveIndex = startWaveIndex;
        PlayerStats.isGameOver = false;
    }

    private void Update()
    {
        if (!PlayerStats.isGameOver)
        {
            if (EnemiesAlive > 0)
            {
                return;
            }
            if (_waveIndex == waves.Length)
            {
                _gms.CheckGame(false);
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

    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[_waveIndex];
        EnemiesAlive = wave.count;
        PlayerStats.Rounds++;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return  new WaitForSeconds(wave.rate);
        }
        _waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
    }
}
