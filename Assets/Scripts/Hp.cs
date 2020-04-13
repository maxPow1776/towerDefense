﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public GameObject _fighter;
    public RectTransform _rectTransform;
    public int _health;
    public bool _isMainTower = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isMainTower)
        {
            if (_fighter == null)
                Destroy(gameObject);
            else
            {
                gameObject.GetComponent<Text>().text = _health.ToString();
                var position = _fighter.transform.position;
                position.y += 1;
                _rectTransform.position = Camera.main.WorldToScreenPoint(position);
            }
        } else
        {
            if (_fighter == null)
                Destroy(gameObject);
            else
            {
                gameObject.GetComponent<Text>().text = _health.ToString();
            }
        }
    }
}