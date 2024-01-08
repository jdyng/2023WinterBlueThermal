using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CurrentBullet : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private UI_MaxBullet _parent;

    protected virtual void Init()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _parent = GetComponentInParent<UI_MaxBullet>();
    }

    private void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshPro.text = $"{_parent._weaponData.currentAmmo} /";
    }
}
