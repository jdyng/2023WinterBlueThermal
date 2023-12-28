using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Entity
{
    [HideInInspector]
    public bool _onExecution = false;    //처형 발생 여부

    protected NavMeshAgent _agent;
    protected Animator _animator;

    [SerializeField]
    private int _attackDamage;   //공격력

    [Header("ChasingAndScattering")]
    [SerializeField] private float _chasingTime;  //추격 시간
    [SerializeField] private float _scatteringTime;   //흩어짐 시간
    [SerializeField] private float _scatteringRange;
    [SerializeField] private Transform _chasingTarget;

    [Header("Attack")]
    [SerializeField] private float _attackRange;
    [SerializeField] private float _readyToAttackTime;
    [SerializeField] private float _attackDelayTime;
    private float _currentAttackTime;

    private bool isChasing = false;

    

    //===========================================================================================================================

    protected abstract void Attack(Transform chasingTarget, int attackDamage);

    protected virtual IEnumerator Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        float currentChasingTime = 0;
        while (currentChasingTime <= chasingTime)
        {
            agent.SetDestination(chasingTarget.position);
            _animator.SetBool("isWalking", true);
            StartCoroutine(StopWhenArrive());
            currentChasingTime += Time.deltaTime;
            yield return null;
        }
    }

    protected virtual IEnumerator Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        Vector3 _scatteringTargetPoint;

        while (true)
        {
            if (RandomPoint(scatteringRange, out _scatteringTargetPoint))
            {
                agent.SetDestination(_scatteringTargetPoint);
                StartCoroutine(StopWhenArrive());
                break;
            }
        }

        yield return new WaitForSeconds(scatteringTime);
    }

    protected virtual bool RandomPoint(float range, out Vector3 result)
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

    protected override void Dead() //죽음
    {
        if (_currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void Init()
    {
        base.Init();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private IEnumerator DoChaseAndScatter()
    {
        while (true)
        {
            isChasing = true;
            yield return StartCoroutine(Chase(_agent, _chasingTarget, _chasingTime));

            isChasing = false;
            yield return StartCoroutine(Scatter(_agent, _scatteringTime, _scatteringRange));
        }
    }

    private void Start()
    {
        StartCoroutine(DoChaseAndScatter());
    }

    private void Update()
    {
        PrepareToAttack();
    }

    private void PrepareToAttack()
    {
        if (isChasing)
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
                DoAttack();
                _currentAttackTime = _readyToAttackTime - _attackDelayTime;
            }
        }
    }

    private void DoAttack()
    {
        Attack(_chasingTarget, _attackDamage);
    }

    private IEnumerator StopWhenArrive()
    {
        while (!(_agent.remainingDistance <= 0.1f))
        {
            yield return null;
        }
        _animator.SetBool("isWalking", false);
    }

}
