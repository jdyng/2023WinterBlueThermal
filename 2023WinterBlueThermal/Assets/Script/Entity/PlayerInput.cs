using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : EntityMove
{
    Vector3 moveDirection = new Vector3(0, 0, 0);
    Rigidbody rigid;
    float inputX;
    float inputZ;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(inputX, 0, inputZ);
    }

    private void FixedUpdate()
    {
        MoveEntity(moveDirection);
    }
}
