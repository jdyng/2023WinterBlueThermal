using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> _enemyList = new List<Enemy>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach(Enemy enemy in _enemyList)
            {
                enemy._playerInArea = true;
            }
        }
    }
}
