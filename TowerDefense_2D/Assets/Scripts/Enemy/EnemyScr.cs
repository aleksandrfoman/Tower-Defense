using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScr : MonoBehaviour
{
    public float health = 100;
    private float maxHealth = 100;
    public int valueMoney = 50;
    public Image HealthBar;

    private void Start()
    {
        maxHealth = health;
    }

    private void Update()
    {
       CheckIsAlive();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        HealthBar.fillAmount = health / maxHealth;
    }
    void CheckIsAlive()
    {
        if (health <= 0)
        {

            PlayerStats.Money += valueMoney;
            Destroy(gameObject);

            WaveSpawner.EnemiesAlive--;
        }
    }
    public void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
