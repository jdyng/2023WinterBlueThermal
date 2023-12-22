using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileMonster : Enemy
{
    [SerializeField] private float _keepDistance; //플레이어와의 간격 유지 거리

    [Header("SetProjectile")]
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxRange;

    protected override void Init()
    {
        base.Init();
        _agent.stoppingDistance = _keepDistance;
    }

    protected override void Attack(Transform chasingTarget, int attackDamage)
    {
        GameObject projectile = Instantiate(_projectile);
        projectile.transform.position = this.gameObject.transform.position; 
        projectile.GetComponent<Projectile>().SetDamage(attackDamage);
        projectile.GetComponent<Projectile>().SetRange(_maxRange);
        projectile.GetComponent<Projectile>().SetSpeed(_speed);
        projectile.transform.LookAt(chasingTarget);
    }

    protected override IEnumerator Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        float currentChasingTime = 0;
        while (currentChasingTime <= chasingTime)
        {
            agent.SetDestination(chasingTarget.position);
            currentChasingTime += Time.deltaTime;
            yield return null;
        }
    }

    protected override IEnumerator Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        Vector3 _scatteringTargetPoint;

        while (true)
        {
            if (RandomPoint(scatteringRange, out _scatteringTargetPoint))
            {
                agent.SetDestination(_scatteringTargetPoint);
                break;
            }
        }

        yield return new WaitForSeconds(scatteringTime);
    }

    protected override bool RandomPoint(float range, out Vector3 result)
    {
        Vector3 randomPoint = gameObject.transform.position + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
