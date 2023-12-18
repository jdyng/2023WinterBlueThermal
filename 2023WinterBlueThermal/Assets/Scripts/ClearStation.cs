using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearStation : MonoBehaviour
{
    [SerializeField]
    private List<Define.KeyColor> _requiredKey = new List<Define.KeyColor>();

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
                List<Define.KeyColor> hasKeys = LevelManager.Instance.getKeys();

                foreach (Define.KeyColor requiredKey in _requiredKey)
                {
                    if (hasKeys.Contains(requiredKey) == false)
                    {
                        print("열쇠를 찾으세요!");
                        return;
                    }
                }
                
                print("게임을 클리어했습니다.!");
                LevelManager.Instance.InitKey();
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
