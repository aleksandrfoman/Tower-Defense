using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; //Скорость врага
    private Transform target; //Таргет вейпоинта
    private int wavepointIndex = 0;
    private EnemyScr enemyScr;

    private void Start()
    {
        target = Waypoints.points[0];
        enemyScr = GetComponent<EnemyScr>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            enemyScr.EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
