using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : BaseState
{
    private Player _playerState;
    private WeaponController _weaponController;

    public Move(Player playerState, WeaponController weaponController) : base("Move", playerState, weaponController)
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
        
        if (_playerState._playerHp <= 0)
        {
            _playerState.ChangeState(_playerState.deadState);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            _weaponController._animator.SetBool("move", false);
            _playerState.ChangeState(_playerState.idleState);
        }
    }
}
