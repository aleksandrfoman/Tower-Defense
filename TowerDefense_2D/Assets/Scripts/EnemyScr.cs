using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScr : MonoBehaviour
{
    public float speed = 10f;
    public float health = 100;
    private float maxHealth = 100;
    public int valueMoney = 50;
    public Image HealthBar;


    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
        maxHealth = health;
    }

    private void Update()
    {
        Move();
        CheckIsAlive();
    }

    private void Move()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage(int damage)
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

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
