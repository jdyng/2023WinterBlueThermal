using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MeleeMonster : Enemy
{
    protected override void Attack(Transform chasingTarget, int attackDamage)
    {
        _animator.SetTrigger("Attack");
        chasingTarget.GetComponent<Player>().GetDamage(attackDamage);
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
}
