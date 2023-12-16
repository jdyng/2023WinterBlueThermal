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
        // TODO : ��ǲ ���� ����� �ٸ� Ŭ������ �ű�
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(inputX, 0, inputZ);
    }

    private void FixedUpdate()
    {
        MoveEntity(moveDirection);
    }
}
