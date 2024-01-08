using UnityEngine;
using UnityEngine.AI;

public class ProjectileMonster : Enemy
{
    [SerializeField] private float _keepDistance; //�÷��̾���� ���� ���� �Ÿ�

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

    protected override void Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        _agent.stoppingDistance = _keepDistance;
        base.Chase(agent, chasingTarget, chasingTime);

        float distance = Vector3.Distance(agent.transform.position, chasingTarget.transform.position);
        if (distance < _keepDistance)
        {
            _animator.SetBool("isWalking", false);
        }
    }

    protected override void Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        _agent.stoppingDistance = 0f;
        base.Scatter(_agent, scatteringTime, scatteringRange);
        //���� �߰� ���
    }

    protected override bool RandomPoint(float range, out Vector3 result)
    {
        //���� �߰� ���
        return base.RandomPoint(range, out result);
        //���� �߰� ���
    }
}
