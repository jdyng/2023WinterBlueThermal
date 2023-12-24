using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void Update()
    {
        // �Ѿ��� ���� �������� �̵���ŵ�ϴ�.
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
