using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Define.KeyColor _keyColor;

    private bool interaction = false;

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
                List<Define.KeyColor> keys = LevelManager.Instance.getKeys();
                if(keys.Contains(_keyColor))
                {
                    Destroy(gameObject);
                    return;
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
