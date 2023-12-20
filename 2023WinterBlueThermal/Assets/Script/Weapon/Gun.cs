using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GunData _gunDate;
    [SerializeField]
    private Transform _muzzle;

    float _timeSinceLastShot;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        PlayerInput.shootInput += Shoot;
        PlayerInput.reloadInput += StartReload;
        _timeSinceLastShot = 0;

    }
    private void StartReload()//액션
    {
        if (!_gunDate.reloading)
        {
            if (this.gameObject.activeSelf)
            {
                Debug.Log(this.gameObject.activeSelf);
                StartCoroutine(Reload());
            }
        }
    }

    private void Shoot()//액션
    {
        if (_gunDate.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(_muzzle.transform.position, _muzzle.forward, out RaycastHit hitInfo, _gunDate.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                }
                OnGunShot();
            }
        }
    }

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(_muzzle.position, _muzzle.forward);
    }


    private void OnDisable()
    {
        _gunDate.reloading = false;
    }

    private IEnumerator Reload()
    {
        _gunDate.reloading = true;

        yield return new WaitForSeconds(_gunDate.reloadTime);

        _gunDate.currentAmmo = _gunDate.magSize;

        _gunDate.reloading = false;
    }

    private bool CanShoot()
    {
        if (_gunDate.reloading)
            return false;
        else if (_timeSinceLastShot < 1f / (_gunDate.fireRate / 60f))
            return false;

        return true;
    }

    private void OnGunShot()
    {
        Debug.Log("Shoot!");
        _gunDate.currentAmmo--;
        _timeSinceLastShot = 0;
    }
}
