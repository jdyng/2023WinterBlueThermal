using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Item_ammo : Item
{
    int plusAmmo = (maxAmmo / 4);

    protected override void ItemEffect()
    {
        Debug.Log("ammo added");
        if (currentAmmo + plusAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        else if (currentAmmo + plusAmmo < maxAmmo)
        {
            currentAmmo += plusAmmo;
        }
        else
        {

        }
    }
}