using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TowerScr : MonoBehaviour
{
    public GameObject projectile;
    private float fireCountdown = 0f;
    public float range;
    public float fireRate;
    public Transform shootPoint;
    public Transform target;
    private string enemyTag = "Enemy";

    private void Start()
    {
        InvokeRepeating("SearchTarget",0f, 0.1f);
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector2 dir = target.position - gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        if (fireCountdown <= 0)
        {
            Shoot(target);
           // fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void SearchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shoreterstDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(gameObject.transform.position, enemy.transform.position);
            if (distanceToEnemy < shoreterstDistance)
            {
                shoreterstDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shoreterstDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    void Shoot(Transform enemy)
    {
        fireCountdown = fireRate;
        GameObject proj = Instantiate(projectile);
       // proj.GetComponent<TowerProjectileScr>().selfProjectile = gm.allProjectile[(int) selfType];
        proj.transform.position = shootPoint.transform.position;
        proj.GetComponent<TowerProjectileScr>().SetTarget(enemy);
    }
}
