using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileScr : MonoBehaviour
{
    private Transform target;
    public TowerProjectile selfProjectile;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = selfProjectile.color;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                target.GetComponent<Enemy>().TakeDamage(selfProjectile.damage);
                Destroy(gameObject);
            }
            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * selfProjectile.speed);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }
}
