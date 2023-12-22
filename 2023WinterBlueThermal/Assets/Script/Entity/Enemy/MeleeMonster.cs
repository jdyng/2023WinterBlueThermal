using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MeleeMonster : Enemy
{
    protected override void Attack(Transform chasingTarget, int attackDamage)
    {
        chasingTarget.GetComponent<Player>().GetDamage(attackDamage);
    }

    protected override IEnumerator Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        float currentChasingTime = 0;
        while (currentChasingTime <= chasingTime)
        {
            agent.SetDestination(chasingTarget.position);
            currentChasingTime += Time.deltaTime;
            yield return null;
        }
    }

    protected override IEnumerator Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        Vector3 _scatteringTargetPoint;

        while (true)
        {
            if (RandomPoint(scatteringRange, out _scatteringTargetPoint))
            {
                agent.SetDestination(_scatteringTargetPoint);
                break;
            }
        }

        yield return new WaitForSeconds(scatteringTime);
    }

    protected override bool RandomPoint(float range, out Vector3 result)
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
}
