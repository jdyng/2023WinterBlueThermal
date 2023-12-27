using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Define.KeyColor _keyColor;

    private bool interaction = false;

    private Animator _animator;
    private bool isOpening = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        OnInteraction();
    }

    private void OnInteraction()
    {
        if (interaction == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                List<Define.KeyColor> keys = LevelHandler.Instance.getKeys();
                if (keys.Contains(_keyColor))
                {
                    if (isOpening == false)
                    {
                        _animator.SetTrigger("Open");
                        isOpening = true;
                        return;
                    }
                    else
                    {
                        _animator.SetTrigger("Close");
                        isOpening = false;
                        return;
                    }
                }
                print("키가 없습니다.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interaction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interaction = false;
        }
    }
}
