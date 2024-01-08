using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Chainsaw : Weapon
{
    protected override void Init()
    {
        base.Init();
    }

    override protected void Attack()
    {
        base.Attack();
        _weaponData.currentAmmo = _weaponData.maxAmmo;
        RaycastAttack(_muzzle.forward);
    }
}
