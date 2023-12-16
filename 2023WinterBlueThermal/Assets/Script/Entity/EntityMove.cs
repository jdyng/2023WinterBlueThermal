using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5;

    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    protected void MoveEntity(Vector3 direction)
    {
        rigid.AddForce (direction* moveSpeed);
    }
}
