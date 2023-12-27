using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player : Entity
{
    private WeaponController _weaponController;

    public void Shoot()
    {
        _weaponController.ShootSelectWeapon();
    }

    public void SwichingWeapon(int weaponIndex)
    {
        _weaponController.WeaponSwiching(weaponIndex);
    }

    public void GetHeal(int index)
    {
        _currentHp += index;
    }

    public void GetAmmo(int weaponIndex, int index)
    {
        _weaponController.GetAmmo(weaponIndex, index);
    }

    protected override void Init()
    {
        base.Init();

        _weaponController = GetComponentInChildren<WeaponController>();
    }
}
