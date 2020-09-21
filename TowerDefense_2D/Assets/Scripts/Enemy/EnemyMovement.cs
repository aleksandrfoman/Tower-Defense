using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _target; //Waypoint target
    private int _wavepointIndex = 0;
    private EnemyScr _enemyScr;

    private void Start()
    {
        _target = Waypoints.points[0];
        _enemyScr = GetComponent<EnemyScr>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemyScr.speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (_wavepointIndex >= Waypoints.points.Length - 1)
        {
            _enemyScr.EndPath();
            return;
        }
        _wavepointIndex++;
        _target = Waypoints.points[_wavepointIndex];
    }
}
