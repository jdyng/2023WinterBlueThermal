using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public string name;
    protected Player _state;
    protected WeaponController _controller;
    public BaseState(string name, Player playerState, WeaponController controller)
    {
        this.name = name;
        this._state = playerState;
        _controller = controller;
    }

    public virtual void OnStatEnter() {  } 
    public virtual void OnStateUpdate() {  }
    public virtual void OnStatExit() {  }
}
