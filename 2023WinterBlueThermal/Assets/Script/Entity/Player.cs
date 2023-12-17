using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player : Entity
{
    Vector3 moveDirection;


    [SerializeField]
    float rotateYSpeed = 10f;
    float inputX;
    float inputZ;
    float mouseY;


    public override void Init()
    {
        base.Init();

        moveDirection = new Vector3(0, 0, 0);

        // TODO : 인풋 관련 기능은 다른 클래스로 옮김
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        mouseY = 0;
    }

    private void Update()
    {
        // TODO : 인풋 관련 기능은 다른 클래스로 옮김
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        mouseY += Input.GetAxis("Mouse X")* rotateYSpeed;
        if (mouseY < 0) { mouseY += 360; }
        if (mouseY > 360) { mouseY -= 360; }

        moveDirection = new Vector3(inputX, 0, inputZ);

        //점프 테스트
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Jump");
        //    rigid.AddForce(new Vector3(0, 500, 0));
        //}
    }

    private void FixedUpdate()
    {
        MoveEntity(moveDirection);
        RotateY(mouseY);
    }
}
