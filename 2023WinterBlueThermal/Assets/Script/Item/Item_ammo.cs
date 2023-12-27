using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Item_ammo : Item
{
    protected override void ItemEffect()
    {
        base.ItemEffect();
/*        int plusAmmo = (weapondata.maxAmmo / 4);
        Debug.Log("ammo added");
        if (weapondata.currentAmmo + plusAmmo > weapondata.maxAmmo)
        {
            weapondata.currentAmmo = weapondata.maxAmmo;
        }
        else if (weapondata.currentAmmo + plusAmmo < weapondata.maxAmmo)
        {
            weapondata.currentAmmo += plusAmmo;
        }
        else
        {

        }*/
    }
}