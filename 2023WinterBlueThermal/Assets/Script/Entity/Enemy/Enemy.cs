using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Entity
{
    [HideInInspector]
    public bool _onExecution = false;    //Ã³Çü ¹ß»ý ¿©ºÎ
    
    [SerializeField]
    protected int _attackDamage;   //°ø°Ý·Â

    [Header("ChasingAndScattering")]
    [SerializeField] private float _chasingTime;  //Ãß°Ý ½Ã°£
    [SerializeField] private float _scatteringTime;   //Èð¾îÁü ½Ã°£
    [SerializeField] private float _scatteringRange;
    [SerializeField] private Transform _chasingTarget;

    [Header("Attack")]
    [SerializeField] private float _attackRange;
    [SerializeField] private float _readyToAttackTime;
    [SerializeField] private float _attackDelayTime;
    private float _currentAttackTime;

    private NavMeshAgent _agent;

    //=========================================================================================================================

    protected abstract void Attack(Transform chasingTarget);

    private IEnumerator DoChaseAndScatter()
    {
        while (true)
        {
            yield return StartCoroutine(Chase(_agent, _chasingTarget, _chasingTime));
            yield return StartCoroutine(Scatter(_agent, _scatteringTime, _scatteringRange));
        }
    }

    protected abstract IEnumerator Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime);

    protected abstract IEnumerator Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange);

    protected abstract bool RandomPoint(float range, out Vector3 result);
    
    protected override void Dead() //Á×À½
    {
        if (_currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
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

    private void DoAttack()
    {
        Attack(_chasingTarget);
    }

    private void DropAmmoOnField()  //Ã³Çü ½Ã Åº¾à ¶³±À
    {
        //ÃßÈÄ ÃÑ±â ¹× ÃÑ¾Ë Á¦ÀÛ ÈÄ ÃÑ¾Ë ¶³±¸´Â ·ÎÁ÷ Ãß°¡
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
