using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;

    private Vector3 _moveDir;

    protected Rigidbody _rigid;

    public void MoveEntity(Vector3 direction)
    {
        _moveDir = transform.rotation * direction;
        transform.position = new Vector3(
            transform.position.x + _moveDir.x * _moveSpeed * Time.deltaTime,
            transform.position.y + _moveDir.y * _moveSpeed * Time.deltaTime,
            transform.position.z + _moveDir.z * _moveSpeed * Time.deltaTime);
    }

    public void RotateY(float targetY)
    {
        transform.rotation = Quaternion.Euler(0, targetY, 0);
    }

    protected virtual void Init()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        Init();
    }
}