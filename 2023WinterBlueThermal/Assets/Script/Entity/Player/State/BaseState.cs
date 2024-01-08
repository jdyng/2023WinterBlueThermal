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

    public virtual void OnStatEnter() { Debug.Log($"{name}시작"); } 
    public virtual void OnStateUpdate() { Debug.Log($"{name}중..."); }
    public virtual void OnStatExit() { Debug.Log($"{name}종료"); }
}
