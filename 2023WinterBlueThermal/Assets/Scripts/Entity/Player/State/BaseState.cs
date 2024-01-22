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

<<<<<<< HEAD:2023WinterBlueThermal/Assets/Script/Entity/Player/State/BaseState.cs
    public virtual void OnStatEnter() { /*Debug.Log($"{name}시작");*/ } 
    public virtual void OnStateUpdate() { /*Debug.Log($"{name}중...");*/ }
    public virtual void OnStatExit() { /*Debug.Log($"{name}종료");*/ }
=======
    public virtual void OnStatEnter() {  } 
    public virtual void OnStateUpdate() {  }
    public virtual void OnStatExit() {  }
>>>>>>> stage:2023WinterBlueThermal/Assets/Scripts/Entity/Player/State/BaseState.cs
}
