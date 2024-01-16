using UnityEngine;
using UnityEngine.Events;

public class GateConsole : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPressed;

    private bool _onInteraction = false;

    private void Update()
    {
        OnConsole();
    }

    private void OnConsole()
    {
        if (_onInteraction && Input.GetKeyDown(KeyCode.F))
        {
            OnPressed.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _onInteraction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _onInteraction = false;
        }
    }
}
