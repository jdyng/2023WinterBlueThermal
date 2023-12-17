using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm : MonoBehaviour
{
    [SerializeField]
    float rotateXSpeed;
    float mouseX;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse Y") * rotateXSpeed;
    }

    private void FixedUpdate()
    {
        RotateX(mouseX);
    }

    protected void RotateX(float x)
    {
        transform.rotation = Quaternion.Euler(x, 0, 0);
    }
}
