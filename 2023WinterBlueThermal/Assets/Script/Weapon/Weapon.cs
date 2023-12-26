using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    protected WeaponData _weaponDate;
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
        Debug.Log("Shoot!");
        _weaponDate.currentAmmo--;
        _timeSinceLastShot = 0;
    }
}
