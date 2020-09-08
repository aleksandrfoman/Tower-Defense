using UnityEngine;

public class TowerProjectileScr : MonoBehaviour
{
    private Transform target; //Таргет врага
    public Color color; //Цвет снаряда
    public int damage; //Урон снаряда
    public float speed;//Скорость снаряда
    public float explosionRadius = 0f; //Если больше 0, снаряд становиться взрывным и наносит в радиусе урон соседним врагам

    // public GameObject imactEffect; Эффект для попадания


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
        transform.LookAt(target);
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
