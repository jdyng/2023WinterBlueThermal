using System.Collections.Generic;
using UnityEngine;

public class ClearStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Define.Scenes _nextScene;
    [SerializeField] private List<Define.KeyColor> _requiredKey = new List<Define.KeyColor>();

    public void Interact()
    {
        List<Define.KeyColor> hasKeys = LevelHandler.Instance.getKeys();

        foreach (Define.KeyColor requiredKey in _requiredKey)
        {
            if (hasKeys.Contains(requiredKey) == false)
            {
                print("���踦 ã������!");
                return;
            }
        }

        SceneManagement.Instance.MoveScene(_nextScene);
        LevelHandler.Instance.InitKey();
    }
}
