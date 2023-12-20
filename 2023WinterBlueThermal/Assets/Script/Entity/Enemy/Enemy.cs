using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    [HideInInspector]
    public bool _onExecution = false;    //처형 발생 여부
    
    [SerializeField]
    protected int _attackDamage;   //공격력

    //private int _executionHp; //처형 발생 조건 체력

    [Header("ChasingAndScattering")]
    [SerializeField]
    protected int _chasingTime;  //추격 시간
    [SerializeField]
    protected int _scatteringTime;   //흩어짐 시간

    protected abstract void Attack();

    protected abstract IEnumerator Chase();

    protected abstract IEnumerator Scatter();

    protected override void Dead() //죽음
    {
        if (_currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    //private void Awake()
    //{
    //    _executionHp = (int)(_hp * 0.1);  //처형 발생 체력은 hp의 10분의 1
    //}

    //private void GetDamage(int hitDamage)   //체력 감소
    //{
    //    _currentHp -= hitDamage;
    //    ExecutionOccur();
    //    Dead();
    //}

    //private void ExecutionOccur()   //처형 발생
    //{
    //    if ((_currentHp <= _executionHp) && (_currentHp > 0))
    //    {
    //        _onExecution = true;
    //    }
    //}

    private void DropAmmoOnField()  //처형 시 탄약 떨굼
    {
        //추후 총기 및 총알 제작 후 총알 떨구는 로직 추가
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //추후에 총기 및 총알 제작후 DecreaseHP() 호출하면서
            //파라미터로 총알 데미지 넘겨줌
        }
    }
}
