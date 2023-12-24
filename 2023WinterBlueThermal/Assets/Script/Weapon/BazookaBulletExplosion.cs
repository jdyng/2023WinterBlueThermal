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
        Debug.Log(other.transform.name);
        Entity entity = other.transform.GetComponent<Entity>();
        entity.GetDamage(_weaponData.damage);
    }
}
