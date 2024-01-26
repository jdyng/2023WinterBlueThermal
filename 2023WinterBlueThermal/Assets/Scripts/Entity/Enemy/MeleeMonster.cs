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
        //���� �߰� ���
        base.Chase(agent, chasingTarget, chasingTime);
        //���� �߰� ���
    }

    protected override void Scatter(NavMeshAgent agent, float scatteringTime, float scatteringRange)
    {
        //���� �߰� ���
        base.Scatter(_agent, scatteringTime, scatteringRange);
        //���� �߰� ���
    }

    protected override bool RandomPoint(float range, out Vector3 result)
    {
        //���� �߰� ���
        return base.RandomPoint(range, out result);
        //���� �߰� ���
    }
}
