using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEditor.Playables;
using UnityEngine;

public class GatlingGun : Weapon
{
    [SerializeField]
    private float _bulletSpread;

    //private void FixedUpdate()//개틀링건 탄퍼짐 확인
    //{
    //    var xError = GetRandomNormalDistribution(0f, _bulletSpread);
    //    var yError = GetRandomNormalDistribution(0f, _bulletSpread);
    //    var zError = GetRandomNormalDistribution(0f, _bulletSpread);

    //    var fireDirection = _muzzle.forward;

    //    fireDirection = Quaternion.AngleAxis(xError, transform.forward) * fireDirection;
    //    fireDirection = Quaternion.AngleAxis(yError, transform.right) * fireDirection;
    //    fireDirection = Quaternion.AngleAxis(zError, transform.up) * fireDirection;


    //    Debug.DrawRay(_muzzle.position, fireDirection);
    //}

    override protected void Attack()
    {

        var xError = GetRandomNormalDistribution(0f, _bulletSpread);
        var yError = GetRandomNormalDistribution(0f, _bulletSpread);


        var fireDirection = _muzzle.forward;

        fireDirection = Quaternion.AngleAxis(xError, Vector3.right) * fireDirection;
        fireDirection = Quaternion.AngleAxis(yError, Vector3.up) * fireDirection;

        if (Physics.Raycast(_muzzle.transform.position, fireDirection, out RaycastHit hitInfo, _weaponDate.maxDistance))
        {
            Debug.Log(hitInfo.transform.name);
            Enemy entity = hitInfo.transform.GetComponent<Enemy>();
            entity.GetDamage(_weaponDate.damage);
        }
    }

    private float GetRandomNormalDistribution(float mean, float standard)  // 정규 분포로 부터 랜덤값을 가져오는 함수 
    {
        var x1 = Random.Range(0f, 1f);
        var x2 = Random.Range(0f, 1f);
        return mean + standard * (Mathf.Sqrt(-2.0f * Mathf.Log(x1)) * Mathf.Sin(2.0f * Mathf.PI * x2));
    }
}
