using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : BaseState
{
    private Player _playerState;
    private WeaponController _weaponController;

    public Dead(Player playerState, WeaponController weaponController) : base("Dead", playerState, weaponController)
    {
        _playerState = playerState;
        _weaponController = weaponController;
    }
    public override void OnStatEnter()
    {
        base.OnStatEnter();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }
}
