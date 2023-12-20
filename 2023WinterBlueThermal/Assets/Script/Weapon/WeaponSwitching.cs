using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform[] weapons;

    [Header("Keys")]
    [SerializeField]
    private KeyCode[] keys;

    [Header("Setting")]
    [SerializeField]
    private float swichTime;

    private int selectedWeapon;
    private float timeSinceLastSwitch;

    private void Start()
    {
        SetWeapon();
        Select(selectedWeapon);
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        for(int i = 0; i<keys.Length;i++)
        {
            if (Input.GetKeyDown(keys[i])&&timeSinceLastSwitch>=swichTime)
            {
                selectedWeapon = i;
            }
        }

        if(previousSelectedWeapon != selectedWeapon)
        {
            Select(selectedWeapon);
        }
        timeSinceLastSwitch += Time.deltaTime;
    }

    private void Select(int weaponIndex)
    {
        for(int i = 0; i<weapons.Length;i++)
        {
            weapons[i].gameObject.SetActive(i==weaponIndex);
        }

        timeSinceLastSwitch = 0f;

        OnWeaponSelected();
    }

    private void OnWeaponSelected()
    {
        print("selected new weapon...");
    }

    private void SetWeapon()
    {
        weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i);
        }

        if (keys == null)
        {
            keys = new KeyCode[weapons.Length];
        }
    }
}
