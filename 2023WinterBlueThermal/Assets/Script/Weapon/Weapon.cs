using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    public WeaponData _weaponData;
    [SerializeField]
    protected Transform _muzzle;

    [HideInInspector]
    public WeaponController _weaponController;

    private float _timeSinceLastShot;

    public void Shoot()
    {
        if (_weaponData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                _weaponController._animator.SetBool("attacking", true);
                Attack();
                OnGunShot();
            }
        }
    }

    protected virtual void Init()
    {
        _weaponController = GetComponentInParent<WeaponController>();
        _timeSinceLastShot = 0;
    }
    private void Awake()
    {
        Init();
    }

    protected virtual void Attack()
    {
        _weaponController._animator.SetTrigger("fire");
    }

    protected virtual void AttackEnd()
    {
        _weaponController._animator.SetBool("attacking", false);
    }
    protected void RaycastAttack(Vector3 AttackDir)
    {
        if (Physics.Raycast(_muzzle.transform.position, AttackDir, out RaycastHit hitInfo, _weaponData.maxDistance))
        {
            Enemy entity = hitInfo.transform.GetComponent<Enemy>();

            if (entity != null)
            {
                Debug.Log(entity.name);
                entity.GetDamage(_weaponData.damage);
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
        if (_timeSinceLastShot < 1f / (_weaponData.fireRate / 60f))
            return false;

        return true;
    }

    private void OnGunShot()
    {
        _weaponData.currentAmmo--;
        _timeSinceLastShot = 0;
    }
}
