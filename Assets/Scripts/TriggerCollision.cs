using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour
{
    [SerializeField] private GameObject _tower;
    private GameObject _rival;
    private bool _isLock = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CapsuleCollider2D>() && !_isLock)
        {
            _rival = collision.gameObject;
            _tower.GetComponent<TowerFighter>()._target = _rival;
            Debug.Log("вошел в область");
            _isLock = true;
        }
    }

    private void Update()
    {
        if (!_rival)
            _isLock = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CapsuleCollider2D>() && collision.gameObject == _rival)
        {
            _isLock = false;
        }
        Debug.Log("вышел из области");
    }
}
