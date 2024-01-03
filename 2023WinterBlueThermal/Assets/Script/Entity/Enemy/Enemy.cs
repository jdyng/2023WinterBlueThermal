using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Entity
{
    private enum EnemyState
    {
        IDLE,
        CHASE,
        SCATTER,
    }
    [SerializeField]
    private EnemyState _startEnemyState;
    private EnemyState _enemyState;

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
    private float _currentChasingTime;
    private float _currentScatteringTime;
    private bool _isScattering = false;

    [Header("Sound")]
    [SerializeField] private AudioClip _attackingClip;
    [SerializeField] private AudioClip _cryingClip;
    [SerializeField] private AudioClip _walkingClip;
    private AudioSource _audioSource;

    [Header("Attack")]
    [SerializeField] private float _attackRange;
    [SerializeField] private float _readyToAttackTime;
    [SerializeField] private float _attackDelayTime;
    private float _currentAttackTime;

    //===========================================================================================================================

    protected abstract void Attack(Transform chasingTarget, int attackDamage);

    protected virtual void Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        _animator.SetBool("isWalking", true);

        agent.SetDestination(chasingTarget.position);
        PrepareToAttack();
    }

    protected virtual void Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        Vector3 _scatteringTargetPoint;

        _animator.SetBool("isWalking", true);

        while (true)
        {
            if (RandomPoint(scatteringRange, out _scatteringTargetPoint))
            {
                agent.SetDestination(_scatteringTargetPoint);
                break;
            }
        }
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
        _audioSource = GetComponent<AudioSource>();
        _enemyState = _startEnemyState;
    }

    private void Start()
    {
        if (_enemyState == EnemyState.CHASE || _enemyState == EnemyState.SCATTER)
        {
            _audioSource.clip = _walkingClip;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }

    private void Update()
    {
        UpdateFSM();
    }

    private void UpdateFSM()
    {
        switch (_enemyState)
        {
            case EnemyState.IDLE:
                Idle();
                break;
            case EnemyState.CHASE:
                DoChase();
                break;
            case EnemyState.SCATTER:
                DoScatter();
                break;
        }
    }

    private void Idle()
    {
        _currentScatteringTime += Time.deltaTime;
        if (_currentScatteringTime >= _scatteringTime)
        {
            _audioSource.Stop();
            _audioSource.clip = _walkingClip;
            _audioSource.loop = true;
            _audioSource.Play();

            _currentScatteringTime = 0f;
            _enemyState = EnemyState.CHASE;
        }

        SeeToPlayer();
    }

    private void DoChase()
    {
        _isScattering = false;
        _currentChasingTime += Time.deltaTime;

        if (_currentChasingTime >= _chasingTime)
        {
            _audioSource.Stop();
            _audioSource.clip = _walkingClip;
            _audioSource.loop = true;
            _audioSource.Play();

            _currentChasingTime = 0f;
            _enemyState = EnemyState.SCATTER;
        }

        Chase(_agent, _chasingTarget, _chasingTime);
    }

    private void DoScatter()
    {
        _currentScatteringTime += Time.deltaTime;

        if (_currentScatteringTime >= _scatteringTime)
        {
            _audioSource.Stop();
            _audioSource.clip = _walkingClip;
            _audioSource.loop = true;
            _audioSource.Play();

            _isScattering = false;
            _currentScatteringTime = 0f;
            _enemyState = EnemyState.CHASE;
        }

        if (_agent.remainingDistance <= 0.1f)
        {
            _audioSource.Stop();
            _audioSource.clip = _cryingClip;
            _audioSource.loop = false;
            _audioSource.Play();

            _animator.SetBool("isWalking", false);
            _enemyState = EnemyState.IDLE;
            return;
        }

        if (_isScattering == true)
        {
            return;
        }

        _isScattering = true;


        Scatter(_agent, _scatteringTime, _scatteringRange);
    }

    private void PrepareToAttack()
    {
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, _chasingTarget.transform.position);

        SeeToPlayer();

        if (distanceToPlayer <= _attackRange)
        {
            _currentAttackTime += Time.deltaTime;
        }
        else
        {
            _currentAttackTime = 0;
        }

        if (_currentAttackTime >= _readyToAttackTime)
        {
            _audioSource.PlayOneShot(_attackingClip);

            Attack(_chasingTarget, _attackDamage);
            _currentAttackTime = _readyToAttackTime - _attackDelayTime;
        }
    }

    private void SeeToPlayer()
    {
        Vector3 targetDirection = _chasingTarget.gameObject.transform.position - this.transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(targetDirection);

        // 부드러운 회전을 위해 slerp 사용
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, Time.deltaTime * 4f);
    }
}

