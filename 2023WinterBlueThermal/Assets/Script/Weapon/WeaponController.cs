using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponController : MonoBehaviour
{
    public Animator _animator;

    [Header("References")]
    [SerializeField]
    public Weapon[] _weapons;

    [SerializeField]
    public WeaponData[] _weaponDatas;

    [Header("Setting")]
    [SerializeField]
    private float _swichTime;

    public int _selectedWeapon;
    private int _previousSelectedWeapon;
    private float _timeSinceLastSwitch;

    public void ShootSelectWeapon()
    {
        _weapons[_selectedWeapon].Shoot();
        _animator.SetBool("attacking", true);
    }

    public void ShootEndSelectWeapon()
    {
        _animator.SetBool("attacking", false);
    }

    public void WeaponSwiching(int weaponIndex)
    {
        if (_timeSinceLastSwitch >= _swichTime)
        {
            _selectedWeapon = weaponIndex;
        }
    }

    public void GetAmmo(int weaponIndex, int index)
    {
        _weaponDatas[weaponIndex].currentAmmo += index;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SetWeapon();
        Select();
        _animator = _weapons[_selectedWeapon].GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        ClampAmmo();

        if (_previousSelectedWeapon != _selectedWeapon)
        {
            _previousSelectedWeapon = _selectedWeapon;
            Select();
        }
        _timeSinceLastSwitch += Time.deltaTime;
    }

    public void Select()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].gameObject.SetActive(i == _selectedWeapon);
        }

        _timeSinceLastSwitch = 0f;

        OnWeaponSelected();
    }

    private void OnWeaponSelected()
    {
        _animator = _weapons[_selectedWeapon].GetComponentInChildren<Animator>();
    }

    private void SetWeapon()
    {
        _weapons = new Weapon[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _weapons[i] = transform.GetChild(i).GetComponentInChildren<Weapon>();
        }
    }

    public void ClampAmmo()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (_weaponDatas[i].currentAmmo > _weaponDatas[i].maxAmmo)
            {
                _weaponDatas[i].currentAmmo = _weaponDatas[i].maxAmmo;
            }
            else if (_weaponDatas[i].currentAmmo < 0)
            {
                _weaponDatas[i].currentAmmo = 0;
            }
        }

    }
}
