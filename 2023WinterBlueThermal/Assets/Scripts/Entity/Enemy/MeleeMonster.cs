using UnityEngine;
using UnityEngine.AI;

public class MeleeMonster : Enemy
{
    protected override void Attack(Transform chasingTarget, int attackDamage)
    {
        _animator.SetTrigger("Attack");
        SoundManager.Instance.Play3D("Monsters/Spider/SpiderMeleeAttack", Define.Sound.Effect, this.gameObject.transform.position);
        chasingTarget.GetComponent<Player>().GetDamage(attackDamage);
    }

    protected override void Chase(NavMeshAgent agent, Transform chasingTarget, float chasingTime)
    {
        //이전 추가 기능
        base.Chase(agent, chasingTarget, chasingTime);
        //이후 추가 기능
    }

    protected override void Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        //이전 추가 기능
        base.Scatter(_agent, scatteringTime, scatteringRange);
        //이후 추가 기능
    }

    protected override bool RandomPoint(float range, out Vector3 result)
    {
        //이전 추가 기능
        return base.RandomPoint(range, out result);
        //이후 추가 기능
    }
}
