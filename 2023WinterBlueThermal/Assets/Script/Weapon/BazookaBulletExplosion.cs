using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BazookaBulletExplosion : MonoBehaviour
{
    [SerializeField]
    private WeaponData _weaponData;
    private void OnTriggerEnter(Collider other)
    {
        Entity entity = other.transform.GetComponent<Entity>();
        if (entity != null)
        {
            entity.GetDamage(_weaponData.damage);
        }
    }
}
