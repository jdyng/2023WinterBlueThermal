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
        //이전 추가 기능
        yield return StartCoroutine(base.Chase(agent, chasingTarget, chasingTime));
        //이후 추가 기능
    }

    protected override IEnumerator Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        //이전 추가 기능
        yield return StartCoroutine(base.Scatter(_agent, scatteringTime, scatteringRange));
        //이후 추가 기능
    }

    protected override bool RandomPoint(float range, out Vector3 result)
    {
        //이전 추가 기능
        return base.RandomPoint(range, out result);
        //이후 추가 기능
    }
}
