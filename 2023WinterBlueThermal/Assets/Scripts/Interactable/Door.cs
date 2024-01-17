using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Define.KeyColor _keyColor;

    private Animator _animator;
    private bool isOpening = false;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            List<Define.KeyColor> keys = LevelHandler.Instance.getKeys();

            if (keys.Contains(_keyColor) || _keyColor == Define.KeyColor.NORMAL)
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

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _animator = GetComponent<Animator>();
    }
}
