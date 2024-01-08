using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_MaxBullet : MonoBehaviour
{
    public WeaponData _weaponData;
    private TextMeshProUGUI _textMeshPro;

    protected virtual void Init()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _textMeshPro.text = $"{_weaponData.maxAmmo}";
    }
}
