using System.Collections;
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
        bool isDirectToTarget = DirectToTarget(chasingTarget);

        if (isDirectToTarget == false)
        {
            return;
        }

        _animator.SetTrigger("Attack");
        GameObject projectile = Instantiate(_projectile);
        projectile.transform.position = _startPosition.position;
        projectile.GetComponent<Projectile>().SetProjectile(attackDamage, _maxRange, _speed);
        projectile.transform.LookAt(chasingTarget);
    }

    protected override IEnumerator Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        _agent.stoppingDistance = _keepDistance;
        yield return StartCoroutine(base.Chase(agent, chasingTarget, chasingTime));
        //���� �߰� ���
    }

    protected override IEnumerator Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        _agent.stoppingDistance = 0f;
        yield return StartCoroutine(base.Scatter(_agent, scatteringTime, scatteringRange));
        //���� �߰� ���
    }

    protected override bool RandomPoint(float range, out Vector3 result)
    {
        //���� �߰� ���
        return base.RandomPoint(range, out result);
        //���� �߰� ���
    }

    protected virtual void KeepDistance()
    {
        //�÷��̾�� �Ÿ� ����ﶧ �ڵ����� �Ÿ� ������ ��� �߰� ����
    }

    private bool DirectToTarget(Transform chasingTarget)
    {
        Vector3 directionToPlayer = chasingTarget.position - gameObject.transform.position;
        Vector3 forwardVector = gameObject.transform.forward;
        float angle = Vector2.Angle(directionToPlayer, forwardVector);

        if (angle <= 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
