using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;
    public bool _collision = false;
    
    void Update()
    {
        if(!_collision)
            transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
