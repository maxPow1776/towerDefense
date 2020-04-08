using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTower : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private bool _isEmpty = true;

    private void OnMouseDown()
    {
        if(_isEmpty)
        {
            Instantiate(_prefab, transform.position, Quaternion.identity);
            _isEmpty = false;
        }
    }
}
