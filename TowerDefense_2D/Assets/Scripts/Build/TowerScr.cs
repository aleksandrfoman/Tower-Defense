using UnityEngine;

public class TowerScr : MonoBehaviour
{
    [Header("Use default")]
    public GameObject projectile; //Снаряд для вышки
    private float fireCountdown = 0f; //Переменная для перезарядки
    public float range; //Дальность вышки
    public float fireRate; //Частотать стрельбы
    public Transform shootPoint; //точка спавна снаряда
    public Transform target; //таргет врага
    private string enemyTag = "Enemy"; //Тег врага

    [Header("Use Laser")] //если вышка лазерная
    public bool useLaser = false;
    public int damageOverTime = 30;
    public LineRenderer lineRenderer;

    private void Start()
    {
        InvokeRepeating("SearchTarget",0f, 0.1f);
    }

    private void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot(target);
                // fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void Laser()
    {
        target.GetComponent<EnemyScr>().TakeDamage(damageOverTime*Time.deltaTime);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            //Частицы
        }
        lineRenderer.SetPosition(0,shootPoint.position);
        lineRenderer.SetPosition(1,target.position);
    }

    void LockOnTarget()
    {
        Vector2 dir = target.position - gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

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
        proj.transform.position = shootPoint.transform.position;
        proj.GetComponent<TowerProjectileScr>().SetTarget(enemy);
    }
}
