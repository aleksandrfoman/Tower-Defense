using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScr : MonoBehaviour
{
    public float health = 100; //Enemy
    public float maxHealth = 100;
    public int valueMoney = 50; //For enemy
    public Image HealthBar;
    [Header("HideInInspector")]
    public float speed;
    public float startSpeed = 5f;


    private void Start()
    {
        speed = startSpeed;
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        HealthBar.fillAmount = health / maxHealth;
        CheckIsAlive();
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

    public void StartSlow(float duration,float slowValue)
    {
        StopCoroutine("GetSlow");
        speed = startSpeed;
        StartCoroutine(GetSlow(duration, slowValue));
    }

    IEnumerator GetSlow(float duration, float slowValue)
    {
        speed -= slowValue;
        yield return new WaitForSeconds(duration);
        speed = startSpeed;
    }
}
