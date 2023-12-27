using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    public WeaponData _weaponDate;
    [SerializeField]
    protected Transform _muzzle;

    private float _timeSinceLastShot;

    public void Shoot()
    {
        if (_weaponDate.currentAmmo > 0)
        {
            if (CanShoot())
            {
                Attack();
                OnGunShot();
            }
        }
    }

    public void ClampAmmo()
    {
        if (_weaponDate.currentAmmo > _weaponDate.maxAmmo)
        {
            _weaponDate.currentAmmo = _weaponDate.maxAmmo;
        }
        else if (_weaponDate.currentAmmo < 0)
        {
            _weaponDate.currentAmmo = 0;
        }
    }

    protected virtual void Init()
    {
        _timeSinceLastShot = 0;
    }
    private void Awake()
    {
        Init();
    }

    protected virtual void Attack()
    {

    }
    protected void RaycastAttack(Vector3 AttackDir)
    {
        if (Physics.Raycast(_muzzle.transform.position, AttackDir, out RaycastHit hitInfo, _weaponDate.maxDistance))
        {
            Enemy entity = hitInfo.transform.GetComponent<Enemy>();

            if (entity != null)
            {
                entity.GetDamage(_weaponDate.damage);
            }
        }
    }

    protected void ProjectileAttack(GameObject bullet, Transform muzzleTransform, float bulletSpeed)
    {
        var bulletObj = Instantiate(bullet, muzzleTransform.position, Quaternion.identity);
        bulletObj.GetComponent<Rigidbody>().velocity = _muzzle.forward * bulletSpeed;
    }

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
    }


    private bool CanShoot()
    {
        if (_timeSinceLastShot < 1f / (_weaponDate.fireRate / 60f))
            return false;

        return true;
    }

    private void OnGunShot()
    {
        _weaponDate.currentAmmo--;
        _timeSinceLastShot = 0;
    }
}
