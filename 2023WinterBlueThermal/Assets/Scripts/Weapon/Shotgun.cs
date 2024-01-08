using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private float _bulletSpread;
    [SerializeField]
    private float _bulletCount;

    override protected void Attack()
    {
        base.Attack();
        for (int i = 0; i < _bulletCount; i++)
        {
            var xError = GetRandomNormalDistribution(0f, _bulletSpread);
            var yError = GetRandomNormalDistribution(0f, _bulletSpread);
            var zError = GetRandomNormalDistribution(0f, _bulletSpread);

            var fireDirection = _muzzle.forward;

            fireDirection = Quaternion.AngleAxis(xError, transform.forward) * fireDirection;
            fireDirection = Quaternion.AngleAxis(yError, transform.right) * fireDirection;
            fireDirection = Quaternion.AngleAxis(zError, transform.up) * fireDirection;

            RaycastAttack(fireDirection);
            ShowAttackDir();
        }
    }

    private float GetRandomNormalDistribution(float mean, float standard)
    {
        var x1 = Random.Range(-1f, 1f);
        return mean + standard * x1;
    }

    private void ShowAttackDir()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            var xError = GetRandomNormalDistribution(0f, _bulletSpread);
            var yError = GetRandomNormalDistribution(0f, _bulletSpread);
            var zError = GetRandomNormalDistribution(0f, _bulletSpread);

            var fireDirection = _muzzle.forward;

            fireDirection = Quaternion.AngleAxis(xError, transform.forward) * fireDirection;
            fireDirection = Quaternion.AngleAxis(yError, transform.right) * fireDirection;
            fireDirection = Quaternion.AngleAxis(zError, transform.up) * fireDirection;

            Debug.DrawRay(_muzzle.position, fireDirection);
        }
    }
}
