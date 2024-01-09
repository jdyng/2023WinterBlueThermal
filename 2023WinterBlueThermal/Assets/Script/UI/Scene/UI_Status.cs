using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Status : UI_Scene
{
    public WeaponData _shotgun;
    public WeaponData _gatlingGun;
    public WeaponData _bazooka;

    enum Texts
    {
        ShotgunMaxBullet,
        ShotGunCurrentBullet,
        GatlingGunMaxBullet,
        GatlingGunCurrentBullet,
        BazookaMaxBullet,
        BazookaCurrentBullet,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetText((int)Texts.ShotgunMaxBullet).text = $"{_shotgun.maxAmmo}";
        GetText((int)Texts.GatlingGunMaxBullet).text = $"{_gatlingGun.maxAmmo}";
        GetText((int)Texts.BazookaMaxBullet).text = $"{_bazooka.maxAmmo}";
    }

    int _score = 0;

    private void Update()
    {
        GetText((int)Texts.ShotGunCurrentBullet).text = $"{_shotgun.currentAmmo} /";
        GetText((int)Texts.GatlingGunCurrentBullet).text = $"{_gatlingGun.currentAmmo} /";
        GetText((int)Texts.BazookaCurrentBullet).text = $"{_bazooka.currentAmmo} /";
    }
}