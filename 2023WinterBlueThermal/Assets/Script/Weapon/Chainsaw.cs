using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Chainsaw : Weapon
{
    override protected void Attack()
    {
        _weaponDate.currentAmmo = _weaponDate.maxAmmo;
        RaycastAttack(_muzzle.forward);
    }
}
