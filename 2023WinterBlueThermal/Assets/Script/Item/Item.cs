using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected Collider _collider;
    protected Player player = new Player();

    /*protected virtual void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }*/

    private void Awake()
    {
        //Init();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    protected virtual void ItemEffect()
    {
        Debug.Log("no item");
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            ItemEffect();
            Destroy(gameObject);
        }
    }

}