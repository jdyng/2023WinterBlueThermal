using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    Vector3 moveDirection;
    float inputX;
    float inputZ;

    public override void Init()
    {
        base.Init();

        moveDirection = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        // TODO : 인풋 관련 기능은 다른 클래스로 옮김
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(inputX, 0, inputZ);
    }

    private void FixedUpdate()
    {
        MoveEntity(moveDirection);
    }
}
