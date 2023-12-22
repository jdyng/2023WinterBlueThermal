using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Chainsaw : Weapon
{
    override protected void Attack()
    {
        _weaponDate.currentAmmo = _weaponDate.maxAmmo;
        if (Physics.Raycast(_muzzle.transform.position, _muzzle.forward, out RaycastHit hitInfo, _weaponDate.maxDistance))
        {
            Debug.Log(hitInfo.transform.name);
        }
    }
}
