using UnityEngine;

public class TowerProjectileScr : MonoBehaviour
{
    private Transform target; //Таргет врага
    public Color color; //Цвет снаряда
    public int damage; //Урон снаряда
    public float speed;//Скорость снаряда
    public float explosionRadius = 0f; //Если больше 0, снаряд становиться взрывным и наносит в радиусе урон соседним врагам
    public bool slowPotion = false;//Замедлят?
    public float durationSlow = 2f;//Длительность замедления
    public float slowValue = 4f;//Замедление

    public GameObject impactEffect; //Эффект для попадания

    private EnemyScr enemy;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
        enemy = target.GetComponent<EnemyScr>();
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
    }

    void HitTarget()
    {
        if (impactEffect != null)
        {
            GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        }
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
            if (slowPotion)
            {
                enemy.StartSlow(durationSlow,slowValue);
            }
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
