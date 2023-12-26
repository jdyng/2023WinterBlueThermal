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
        InstantiateBullet(_muzzle);
    }

    private void InstantiateBullet(Transform transform)
    {
        var bulletObj = Instantiate(_bullet, transform.position, Quaternion.identity);
        bulletObj.GetComponent<Rigidbody>().velocity = _muzzle.forward * _bulletSpeed;
    }
}
