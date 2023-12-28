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
        _animator.SetTrigger("Attack");
        GameObject projectile = Instantiate(_projectile);
        projectile.transform.position = _startPosition.position;
        projectile.GetComponent<Projectile>().SetProjectile(attackDamage, _maxRange, _speed);
        projectile.transform.LookAt(chasingTarget);
    }

    protected override IEnumerator Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        //���� �߰� ���
        yield return StartCoroutine(base.Chase(agent, chasingTarget, chasingTime));
        //���� �߰� ���
    }

    protected override IEnumerator Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        //���� �߰� ���
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
}
