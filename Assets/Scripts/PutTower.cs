using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTower : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _zone;
    private bool _isEmpty = true;
    private GameObject _tower;

    private void OnMouseDown()
    {
        if(_isEmpty)
        {
            _tower = Instantiate(_prefab, transform.position, Quaternion.identity);
            _zone.GetComponent<ZoneEnter>().AddTowerInZone(_tower);
            _isEmpty = false;
        }
        
    }

    private void Update()
    {
        if(_tower == null)
        {
            _isEmpty = true;
        }
    }
}
