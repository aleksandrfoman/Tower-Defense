using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileScr : MonoBehaviour
{
    private Transform target;
    public Color color;
    public int damage;
    public float speed;

    public float explosionRadius = 0f;


   // public GameObject imactEffect;


    private void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame);
        //transform.LookAt(target);

    }

    void HitTarget()
    {
        //GameObject effectIns = Instantiate(imactEffect, transform.position, transform.rotation);
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }
    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        enemy.GetComponent<EnemyScr>().TakeDamage(damage);
    }
}
