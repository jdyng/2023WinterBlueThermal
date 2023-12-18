using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private Define.KeyColor _keyColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelHandler.Instance.SetKey(_keyColor);
            Destroy(this.gameObject);
        }
    }
}
