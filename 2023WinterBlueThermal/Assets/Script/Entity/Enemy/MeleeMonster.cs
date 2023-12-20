using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class MeleeMonster : Enemy
{
    [SerializeField]
    private Transform _chasingTarget;
    [SerializeField]
    private float _scatteringRange;

    [Header("Attack")]
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _readyToAttackTime;
    [SerializeField]
    private float _attackDelayTime;
    private float _currentAttackTime;

    private NavMeshAgent _agent;

    private Vector3 ScatteringTargetPoint;

    protected override void Attack()
    {
        _chasingTarget.GetComponent<Player>().GetDamage(_attackDamage);
    }

    protected override IEnumerator Chase()
    {
        float currentChasingTime = 0;
        while (currentChasingTime <= _chasingTime)
        {
            _agent.SetDestination(_chasingTarget.position);
            currentChasingTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(Scatter());
    }

    protected override IEnumerator Scatter()
    {
        while (true)
        {
            if (RandomPoint(_scatteringRange, out ScatteringTargetPoint))
            {
                _agent.SetDestination(ScatteringTargetPoint);
                break;
            }
        }

        yield return new WaitForSeconds(_scatteringTime);

        StartCoroutine(Chase());
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(Chase());
    }

    private void Update()
    {
        PrepareToAttack();
    }

    private bool RandomPoint(float range, out Vector3 result)
    {
        Vector3 randomPoint = gameObject.transform.position + Random.insideUnitSphere * _scatteringRange;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void PrepareToAttack()
    {
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, _chasingTarget.transform.position);

        if (distanceToPlayer < _attackRange)
        {
            _currentAttackTime += Time.deltaTime;
        }
        else
        {
            _currentAttackTime = 0;
        }

        if (_currentAttackTime >= _readyToAttackTime)
        {
            Attack();
            _currentAttackTime = _readyToAttackTime - _attackDelayTime;
        }
    }
}
