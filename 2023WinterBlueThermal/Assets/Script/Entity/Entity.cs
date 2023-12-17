using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    Vector3 moveForce;

    protected Rigidbody rigid;
    CharacterController character;

    private void Awake()
    {
        Init();

    }

    public virtual void Init()
    {
        rigid = GetComponent<Rigidbody>();
        character = GetComponent<CharacterController>();
    }

    protected void MoveEntity(Vector3 direction)
    {
        //moveForce = transform.rotation * new Vector3(direction.x * moveSpeed, 0, direction.z * moveSpeed);
        //character.SimpleMove(moveForce);
        moveForce = transform.rotation * direction;
        transform.position = new Vector3(
            transform.position.x + moveForce.x * moveSpeed * Time.deltaTime,
            transform.position.y + moveForce.y * moveSpeed * Time.deltaTime,
            transform.position.z + moveForce.z * moveSpeed * Time.deltaTime);
    }

    protected void RotateY(float targetY)
    {
        transform.rotation = Quaternion.Euler(0, targetY, 0);
    }
}