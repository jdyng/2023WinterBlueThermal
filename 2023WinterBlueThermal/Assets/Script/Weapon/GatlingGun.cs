using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEditor.Playables;
using UnityEngine;

public class GatlingGun : Weapon
{
    [SerializeField]
    private float _bulletSpread;

    override protected void Attack()
    {
        var xError = GetRandomNormalDistribution(0f, _bulletSpread);
        var yError = GetRandomNormalDistribution(0f, _bulletSpread);
        var zError = GetRandomNormalDistribution(0f, _bulletSpread);

        var fireDirection = _muzzle.forward;

        fireDirection = Quaternion.AngleAxis(xError, transform.forward) * fireDirection;
        fireDirection = Quaternion.AngleAxis(yError, transform.right) * fireDirection;
        fireDirection = Quaternion.AngleAxis(zError, transform.up) * fireDirection;

        RaycastAttack(fireDirection);
        ShowAttackDir();
    }

    private float GetRandomNormalDistribution(float mean, float standard)  // 정규 분포로 부터 랜덤값을 가져오는 함수 
    {
        var x1 = Random.Range(0f, 1f);
        var x2 = Random.Range(0f, 1f);
        return mean + standard * (Mathf.Sqrt(-2.0f * Mathf.Log(x1)) * Mathf.Sin(2.0f * Mathf.PI * x2));
    }

    private void ShowAttackDir()
    {
        var xError = GetRandomNormalDistribution(0f, _bulletSpread);
        var yError = GetRandomNormalDistribution(0f, _bulletSpread);
        var zError = GetRandomNormalDistribution(0f, _bulletSpread);

        var fireDirection = _muzzle.forward;

        fireDirection = Quaternion.AngleAxis(xError, transform.forward) * fireDirection;
        fireDirection = Quaternion.AngleAxis(yError, transform.right) * fireDirection;
        fireDirection = Quaternion.AngleAxis(zError, transform.up) * fireDirection;


        Debug.DrawRay(_muzzle.position, fireDirection);
    }
}
