using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player : Entity
{
    private Vector3 _moveDirection;

    [SerializeField]
    private float _rotateYSpeed = 10f;
    private float _inputX;
    private float _inputZ;
    private float _mouseY;

    protected override void Init()
    {
        base.Init();

        _moveDirection = new Vector3(0, 0, 0);

        // TODO : 인풋 관련 기능은 다른 클래스로 옮김
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _mouseY = 0;
    }

    private void Update()
    {
        // TODO : 인풋 관련 기능은 다른 클래스로 옮김
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputZ = Input.GetAxisRaw("Vertical");

        _mouseY += Input.GetAxis("Mouse X")* _rotateYSpeed;
        if (_mouseY < 0) { _mouseY += 360; }
        if (_mouseY > 360) { _mouseY -= 360; }

        _moveDirection = new Vector3(_inputX, 0, _inputZ);
    }

    private void FixedUpdate()
    {
        MoveEntity(_moveDirection);
        RotateY(_mouseY);
    }
}
