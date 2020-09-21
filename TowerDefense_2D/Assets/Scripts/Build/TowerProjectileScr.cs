using UnityEngine;

public class TowerProjectileScr : MonoBehaviour
{
    private Transform _target; //Enemy target
    public Color color; //Color projectile
    public int damage; //Damage projectile
    public float speed;//Speed projectile
    public float explosionRadius = 0f; //If > 0, projectile = explosion
    public bool slowPotion = false;//Slow?
    public float durationSlow = 2f;
    public float slowValue = 4f;

    public GameObject impactEffect;

    private EnemyScr enemy;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
        enemy = _target.GetComponent<EnemyScr>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
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
            Damage(_target);
            if (slowPotion)
            {
                enemy.StartSlow(durationSlow,slowValue);
            }
        }

        Destroy(gameObject);
    }
    public void SetTarget(Transform enemy)
    {
        _target = enemy;
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
