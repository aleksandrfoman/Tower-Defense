using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScr : MonoBehaviour
{
    public GameObject projectile;
    private Tower selfTower;
    public TowerType selfType;
    private GameController gm;

    private void Start()
    {
        gm = FindObjectOfType<GameController>();
        selfTower = gm.allTowers[(int) selfType];
        gameObject.GetComponent<SpriteRenderer>().color = selfTower.color;
    }

    private void Update()
    {
        if (CanShoot())
        {
            SearchTarget();
        }
        if (selfTower.curCooldown > 0)
        {
            selfTower.curCooldown -= Time.deltaTime;
        }
    }

    bool CanShoot()
    {
        if (selfTower.curCooldown <= 0)
        {
            return true;
        }
        return false;
    }

    void SearchTarget()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float curDist = Vector2.Distance(transform.position, enemy.transform.position);
            if (curDist < nearestEnemyDistance && curDist <= selfTower.range)
            {
                nearestEnemy = enemy.transform;
                nearestEnemyDistance = curDist;
            }
        }

        if (nearestEnemy != null)
        {
            Shoot(nearestEnemy);
        }
    }

    void Shoot(Transform enemy)
    {
        selfTower.curCooldown = selfTower.cooldown;
        GameObject proj = Instantiate(projectile);
        proj.GetComponent<TowerProjectileScr>().selfProjectile = gm.allProjectile[(int) selfType];
        proj.transform.position = transform.position;
        proj.GetComponent<TowerProjectileScr>().SetTarget(enemy);
    }
}
