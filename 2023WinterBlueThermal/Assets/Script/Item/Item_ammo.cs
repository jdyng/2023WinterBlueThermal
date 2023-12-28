using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Item_ammo : Item
{
    enum AmmoType
    {
        Shotgun = 1,
        GatlingGun = 2,
        Bazooka = 3
    }

    [SerializeField]
    AmmoType ammoType;
    [SerializeField]
    int addAmmo;

    protected override void ItemEffect()
    {
        base.ItemEffect();
        Debug.Log((int)ammoType);
        player.GetAmmo((int)ammoType, addAmmo);
        Debug.Log("ammo added");
    }
}