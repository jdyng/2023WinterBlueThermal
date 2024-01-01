using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Chainsaw : Weapon
{
    Animator _animator;

    protected override void Init()
    {
        base.Init();
        
        _animator = GetComponent<Animator>();
    }

    override protected void Attack()
    {
        _weaponData.currentAmmo = _weaponData.maxAmmo;
        RaycastAttack(_muzzle.forward);
    }
}
