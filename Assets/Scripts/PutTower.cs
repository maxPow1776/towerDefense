﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutTower : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _prefabHP;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _zone;
    private bool _isEmpty = true;
    public bool _hasEnemy = false;
    private GameObject _tower;

    private void OnMouseDown()
    {
        if(_isEmpty && !_hasEnemy)
        {
            _tower = Instantiate(_prefab, transform.position, Quaternion.identity);
            var hp = Instantiate(_prefabHP, Vector2.zero, Quaternion.identity);
            hp.GetComponent<Text>().color = Color.green;
            hp.transform.SetParent(_canvas.transform);
            _tower.GetComponent<TowerFighter>()._hp = hp;
            hp.GetComponent<Hp>()._fighter = _tower;
            Debug.Log("add hp for Tower");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("что то вошло в коллизию с местом для башни");
        if (collision.gameObject.GetComponent<EnemyFighter>())
        {
            _hasEnemy = true;
            collision.gameObject.GetComponent<EnemyFighter>()._placeForTower = gameObject; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyFighter>())
        {
            _hasEnemy = false;
            collision.gameObject.GetComponent<EnemyFighter>()._placeForTower = null;
        }
    }
}
