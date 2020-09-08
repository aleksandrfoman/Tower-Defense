﻿using System;
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

    private float countdown = 2f;


    private int waveIndex;
    public int startWaveIndex = 0;

    public Text waveTimerText;

    public GameManager gameManager;

    private void Start()
    {
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
            gameManager.WinLevel();
            this.enabled = false;
        }
        else if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            //return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveTimerText.text = string.Format("{0:00.00}", countdown);
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