using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    WeaponController _controller;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _controller = GetComponentInParent<WeaponController>();
    }

    private void TakeOut()
    {
        _controller.Select();
    }
}
