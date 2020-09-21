using UnityEngine;

public class TowerScr : MonoBehaviour
{
    [Header("Use default")]
    public GameObject projectile; //For tower
    private float _fireCountdown = 0f; //Refresh
    public float range;
    public float fireRate;
    public Transform shootPoint;
    public Transform target; //Enemy target
    private string _enemyTag = "Enemy"; //Tag enemy

    [Header("Use Laser")] // if laser tower
    public bool useLaser = false;
    public int damageOverTime = 30;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;

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
                {
                    lineRenderer.enabled = false;
                   // impactEffect.Stop();
                }
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
            if (_fireCountdown <= 0)
            {
                Shoot(target);
                // _fireCountdown = 1f / fireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    void Laser()
    {
        target.GetComponent<EnemyScr>().TakeDamage(damageOverTime*Time.deltaTime);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            //impactEffect.Play();
            //Частицы
        }
        lineRenderer.SetPosition(0,shootPoint.position);
        lineRenderer.SetPosition(1,target.position);

        /*
        Vector3 dir = shootPoint.position - target.position;
        impactEffect.transform.position = target.transform.position+dir.normalized*.5f;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        */
    }

    void LockOnTarget()
    {
        Vector2 dir = target.position - gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
    void SearchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
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
        _fireCountdown = fireRate;
        GameObject proj = Instantiate(projectile);
        proj.transform.position = shootPoint.transform.position;
        proj.GetComponent<TowerProjectileScr>().SetTarget(enemy);
    }
}
