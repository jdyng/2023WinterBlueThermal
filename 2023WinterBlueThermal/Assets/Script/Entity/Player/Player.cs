using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player : Entity
{
    private WeaponController _weaponController;
    private BaseState currentState;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Move moveState;
    [HideInInspector]
    public Dead deadState;

    public int _playerHp;

    public void Shoot()
    {
        _weaponController.ShootSelectWeapon();
    }
    public void ShootEnd()
    {
        _weaponController.ShootEndSelectWeapon();
    }

    public void SwichingWeapon(int weaponIndex)
    {
        _weaponController.WeaponSwiching(weaponIndex);
    }

    public void GetHeal(int index)
    {
        _currentHp += index;
    }

    public void GetAmmo(int weaponIndex, int index)
    {
        _weaponController.GetAmmo(weaponIndex, index);
    }

    public void ChangeState(BaseState newState)
    {
        currentState.OnStatExit();

        currentState = newState;
        currentState.OnStatEnter();
    }

    protected override void Init()
    {
        base.Init();
        _playerHp = _currentHp;

        _weaponController = GetComponentInChildren<WeaponController>();

        idleState = new Idle(this, _weaponController);
        moveState = new Move(this, _weaponController);
        deadState = new Dead(this, _weaponController);
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.OnStatEnter();
        }

        Managers.UI.ShowSceneUI<UI_Scene>("UI_Status");
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (currentState != null)
        {
            currentState.OnStateUpdate();
        }
        _playerHp = _currentHp;
        
    }

    private BaseState GetInitialState()
    {
        return idleState;
    }
}
