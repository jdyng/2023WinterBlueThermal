using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float _rotateYSpeed = 10f;
    private float _inputX;
    private float _inputZ;
    private float _mouseY;

    private Vector3 _moveDirection;
    private Player _player;
    private WeaponController _weaponController;

    [SerializeField]
    private float _interactionRange = 5f;

    [Header("Keys")]
    [SerializeField]
    private KeyCode[] _keys;


    private void Awake()
    {
        Init();
    }
    protected void Init()
    {
        _player = GetComponent<Player>();
        _weaponController = GetComponentInChildren<WeaponController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _moveDirection = new Vector3(0, 0, 0);
        _mouseY = 0;
    }

    private void Update()
    {
        SetMoveDirection();
        ClampAngleY();
        if (Input.GetMouseButton(0))
        {
            _player.Shoot();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _player.ShootEnd();
        }
        for (int i = 0; i < _keys.Length; i++)//playerInput으로 이동
        {
            if (Input.GetKeyDown(_keys[i]))
            {
                _player.SwichingWeapon(i);
            }
        }

        Interact();
    }

    private void FixedUpdate()
    {
        _player.MoveEntity(_moveDirection);
        _player.RotateY(_mouseY);
    }

    private void SetMoveDirection()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputZ = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector3(_inputX, 0, _inputZ);
    }

    private void ClampAngleY()
    {
        _mouseY += Input.GetAxis("Mouse X") * _rotateYSpeed;
        if (_mouseY < 0) { _mouseY += 360; }
        if (_mouseY > 360) { _mouseY -= 360; }
    }

    private void Interact()
    {
        Camera mainCamera = Camera.main;
        RaycastHit hit;

        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * _interactionRange);
        Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, _interactionRange);

        if (Input.GetKeyDown(KeyCode.F) && hit.collider != null)
        {
            if (hit.collider.CompareTag("InteractiveObject") && hit.collider.isTrigger == false)
            {
                hit.collider.transform.root.GetComponent<IInteractable>().Interact();
            }
        }
    }
}