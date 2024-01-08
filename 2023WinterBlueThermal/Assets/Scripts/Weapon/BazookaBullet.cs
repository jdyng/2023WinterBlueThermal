using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaBullet : MonoBehaviour
{
    public GameObject _explosion;

    private bool _collided;

    private void Awake()
    {
        Init();
        Destroy(gameObject, 5f);
    }
    private void Init()
    {
        _collided = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "PlayerAttack" && !_collided)
        {
            _collided = true;
            
            var explosion = Instantiate(_explosion, collision.contacts[0].point,Quaternion.identity);

            Destroy(explosion,0.2f);
            Destroy(gameObject);
        }
    }
}
