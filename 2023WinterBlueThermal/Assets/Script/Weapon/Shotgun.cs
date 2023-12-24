using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private float _bulletSpread;
    [SerializeField]
    private float _bulletCount;

    //private void FixedUpdate()//���� ź���� Ȯ��
    //{
    //    for (int i = 0; i < _bulletCount; i++)
    //    {
    //        var xError = GetRandomNormalDistribution(0f, _bulletSpread);
    //        var yError = GetRandomNormalDistribution(0f, _bulletSpread);
    //        var zError = GetRandomNormalDistribution(0f, _bulletSpread);


    //        var fireDirection = _muzzle.forward;

    //        fireDirection = Quaternion.AngleAxis(xError, transform.forward) * fireDirection;
    //        fireDirection = Quaternion.AngleAxis(yError, transform.right) * fireDirection;
    //        fireDirection = Quaternion.AngleAxis(zError, transform.up) * fireDirection;

    //        Debug.DrawRay(_muzzle.position, fireDirection);
    //    }
    //}
    override protected void Attack()
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

            if (Physics.Raycast(_muzzle.transform.position, fireDirection, out RaycastHit hitInfo, _weaponDate.maxDistance))
            {
                Debug.Log(hitInfo.transform.name);
                Enemy entity = hitInfo.transform.GetComponent<Enemy>();
                entity.GetDamage(_weaponDate.damage);
            }
        }
    }

    private float GetRandomNormalDistribution(float mean, float standard)
    {
        var x1 = Random.Range(-1f, 1f);
        return mean + standard * x1;
    }
}
