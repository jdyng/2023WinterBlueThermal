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
        _animator.SetTrigger("Attack");
        GameObject projectile = Instantiate(_projectile);
        projectile.transform.position = _startPosition.position;
        projectile.GetComponent<Projectile>().SetProjectile(attackDamage, _maxRange, _speed);
        projectile.transform.LookAt(chasingTarget);
    }

    protected override IEnumerator Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        //이전 추가 기능
        yield return StartCoroutine(base.Chase(agent, chasingTarget, chasingTime));
        //이후 추가 기능
    }

    protected override IEnumerator Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        //이전 추가 기능
        yield return StartCoroutine(base.Scatter(_agent, scatteringTime, scatteringRange));
        //이후 추가 기능
    }

    protected override bool RandomPoint(float range, out Vector3 result)
    {
        //이전 추가 기능
        return base.RandomPoint(range, out result);
        //이후 추가 기능
    }

    protected virtual void KeepDistance()
    {
        //플레이어와 거리 가까울때 자동으로 거리 벌리는 기능 추가 예정
    }
}
