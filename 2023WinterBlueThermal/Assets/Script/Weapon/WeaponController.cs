using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Weapon[] _weapons;

    [Header("Setting")]
    [SerializeField]
    private float _swichTime;

    private int _selectedWeapon;
    private int previousSelectedWeapon;
    private float _timeSinceLastSwitch;

    public void ShootSelectWeapon()
    {
        _weapons[_selectedWeapon].Shoot();
    }

    public void WeaponSwiching(int weaponIndex)
    {
        if (_timeSinceLastSwitch >= _swichTime)
        {
            Debug.Log(weaponIndex);
            _selectedWeapon = weaponIndex;
        }
    }
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SetWeapon();
        Select(_selectedWeapon);
    }

    private void Update()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].ClampAmmo();
        }

        if (previousSelectedWeapon != _selectedWeapon)
        {
            previousSelectedWeapon = _selectedWeapon;
            Select(_selectedWeapon);
        }
        _timeSinceLastSwitch += Time.deltaTime;
    }

    private void Select(int weaponIndex)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].gameObject.SetActive(i == weaponIndex);
        }

        _timeSinceLastSwitch = 0f;

        OnWeaponSelected();
    }

    private void OnWeaponSelected()
    {
        Debug.Log("selected new weapon...");
    }

    private void SetWeapon()
    {
        _weapons = new Weapon[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _weapons[i] = transform.GetChild(i).GetComponentInChildren<Weapon>();
        }
    }
}
