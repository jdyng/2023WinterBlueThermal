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
    // Start is called before the first frame update
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mouseX -= Input.GetAxis("Mouse Y") * _rotateXSpeed;
        _mouseX = Mathf.Clamp(_mouseX, _min, _max);
    }

    private void FixedUpdate()
    {
        RotateX(_mouseX);
    }

    public void RotateX(float x)
    {
        transform.rotation = Quaternion.Euler(x, transform.eulerAngles.y, 0);
    }



}
