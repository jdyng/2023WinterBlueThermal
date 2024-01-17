using UnityEngine;
using UnityEngine.Events;

public class GateConsole : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnPressed;

    public void Interact()
    {
        Debug.Log("상호작용");
        OnPressed.Invoke();
    }
}
