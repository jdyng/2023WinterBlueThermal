using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm : MonoBehaviour
{
    [SerializeField]
    private float _rotateXSpeed = 5;
    [SerializeField]
    private float _min = -90;
    [SerializeField]
    private float _max = 90;
    private float _mouseX;

    private void Update()
    {
        ClampAngleX();
    }

    private void FixedUpdate()
    {
        RotateX(_mouseX);
    }

    private void ClampAngleX()
    {
        _mouseX -= Input.GetAxis("Mouse Y") * _rotateXSpeed;
        _mouseX = Mathf.Clamp(_mouseX, _min, _max);
    }

    private void RotateX(float x)
    {
        transform.rotation = Quaternion.Euler(x, transform.eulerAngles.y, 0);
    }
}
