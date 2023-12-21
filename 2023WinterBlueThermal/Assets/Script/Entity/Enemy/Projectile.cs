using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void Update()
    {
        // 총알을 전진 방향으로 이동시킵니다.
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
