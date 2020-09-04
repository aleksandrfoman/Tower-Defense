using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScr : MonoBehaviour
{
    List<GameObject> wayPoints = new List<GameObject>();
    private int wayIndex = 0;
    public float speed = 10f;
    public float health = 100;
    private float maxHealth = 100;
    public int valueMoney = 50;

    public Image HealthBar;

    private void Start()
    {
        maxHealth = health;
        wayPoints = GameObject.Find("Main Camera").GetComponent<GameController>().wayPoints;
    }

    private void Update()
    {
        Move();
        CheckIsAlive();
    }

    private void Move()
    {
        Vector3 dir = wayPoints[wayIndex].transform.position - transform.position;

        transform.Translate(dir.normalized*Time.deltaTime*speed);

        if (Vector3.Distance(transform.position, wayPoints[wayIndex].transform.position) < 0.1f)
        {
            if (wayIndex < wayPoints.Count - 1)
            {
                wayIndex++;
            }
            else
            {
                EndPath();
            }
        }
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
