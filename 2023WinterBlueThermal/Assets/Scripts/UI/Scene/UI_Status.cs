using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using TMPro;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Experimental.GraphView;

public class UI_Status : UI_Scene
{
    private Player _player;
    private WeaponController _weapons;
    private int _previousSelectedWeapon;

    enum Texts
    {
        ShotgunMaxBullet,
        ShotGunCurrentBullet,
        GatlingGunMaxBullet,
        GatlingGunCurrentBullet,
        BazookaMaxBullet,
        BazookaCurrentBullet,
        CurrentAmmo,
        WeaponNum1,
        WeaponNum2,
        WeaponNum3,
        WeaponNum4,
        PlayersCurrentHP,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<TextMeshProUGUI>(typeof(Texts));

        _player = FindAnyObjectByType<Player>();
        _weapons = _player.GetComponentInChildren<WeaponController>();

        GetText((int)Texts.ShotgunMaxBullet).text = $"{_weapons._weapons[1]._weaponData.maxAmmo}";
        GetText((int)Texts.GatlingGunMaxBullet).text = $"{_weapons._weapons[2]._weaponData.maxAmmo}";
        GetText((int)Texts.BazookaMaxBullet).text = $"{_weapons._weapons[3]._weaponData.maxAmmo}";
        _previousSelectedWeapon = _weapons._selectedWeapon;
    }

    int _score = 0;

    private void Update()
    {
        if (_weapons._selectedWeapon == 0)
        {
            GetText((int)Texts.CurrentAmmo).text = "¡Ä";
        }
        else
        {
            GetText((int)Texts.CurrentAmmo).text = $"{_weapons._weapons[_weapons._selectedWeapon]._weaponData.currentAmmo}";
        }
        GetText((int)Texts.PlayersCurrentHP).text = $"{_player._playerHp}%";
        GetText((int)Texts.ShotGunCurrentBullet).text = $"{_weapons._weapons[1]._weaponData.currentAmmo} /";
        GetText((int)Texts.GatlingGunCurrentBullet).text = $"{_weapons._weapons[2]._weaponData.currentAmmo} /";
        GetText((int)Texts.BazookaCurrentBullet).text = $"{_weapons._weapons[3]._weaponData.currentAmmo} /";

        ShowSelectedWeapon();
    }

    public void ShowSelectedWeapon()
    {
        if(_previousSelectedWeapon != _weapons._selectedWeapon)
        {
            GetText((int)Texts.WeaponNum1).color = Color.gray;
            GetText((int)Texts.WeaponNum2).color = Color.gray;
            GetText((int)Texts.WeaponNum3).color = Color.gray;
            GetText((int)Texts.WeaponNum4).color = Color.gray;

            switch (_weapons._selectedWeapon)
            {
                case 0:
                    GetText((int)Texts.WeaponNum1).color = Color.yellow;
                    break;
                case 1:
                    GetText((int)Texts.WeaponNum2).color = Color.yellow;
                    break;
                case 2:
                    GetText((int)Texts.WeaponNum3).color = Color.yellow;
                    break;
                case 3:
                    GetText((int)Texts.WeaponNum4).color = Color.yellow;
                    break;
            }
            _previousSelectedWeapon = _weapons._selectedWeapon;
        }
    }
}