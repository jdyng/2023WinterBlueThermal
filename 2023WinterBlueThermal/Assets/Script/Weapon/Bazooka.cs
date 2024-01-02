using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Weapon
{
    [SerializeField]
    float _bulletSpeed;
    public GameObject _bullet;

    override protected void Attack()
    {
        base.Attack();
        ProjectileAttack(_bullet, _muzzle, _bulletSpeed);

    }
}
