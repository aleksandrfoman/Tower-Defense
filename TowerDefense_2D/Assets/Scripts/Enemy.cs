using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    List<GameObject> wayPoints = new List<GameObject>();
    private int wayIndex = 0;
    public float speed = 10f;
    public int health = 30;


    private void Start()
    {
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
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void CheckIsAlive()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
