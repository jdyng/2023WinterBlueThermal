using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    [HideInInspector]
    public bool _onExecution = false;    //ó�� �߻� ����
    
    [SerializeField]
    protected int _attackDamage;   //���ݷ�

    //private int _executionHp; //ó�� �߻� ���� ü��

    [Header("ChasingAndScattering")]
    [SerializeField]
    protected int _chasingTime;  //�߰� �ð�
    [SerializeField]
    protected int _scatteringTime;   //����� �ð�

    protected abstract void Attack();

    protected abstract IEnumerator Chase();

    protected abstract IEnumerator Scatter();

    protected override void Dead() //����
    {
        if (_currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    //private void Awake()
    //{
    //    _executionHp = (int)(_hp * 0.1);  //ó�� �߻� ü���� hp�� 10���� 1
    //}

    //private void GetDamage(int hitDamage)   //ü�� ����
    //{
    //    _currentHp -= hitDamage;
    //    ExecutionOccur();
    //    Dead();
    //}

    //private void ExecutionOccur()   //ó�� �߻�
    //{
    //    if ((_currentHp <= _executionHp) && (_currentHp > 0))
    //    {
    //        _onExecution = true;
    //    }
    //}

    private void DropAmmoOnField()  //ó�� �� ź�� ����
    {
        //���� �ѱ� �� �Ѿ� ���� �� �Ѿ� ������ ���� �߰�
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //���Ŀ� �ѱ� �� �Ѿ� ������ DecreaseHP() ȣ���ϸ鼭
            //�Ķ���ͷ� �Ѿ� ������ �Ѱ���
        }
    }
}
