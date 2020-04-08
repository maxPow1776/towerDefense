using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFighter : AbstractFighter
{
    [SerializeField] private GameObject _prefab;
    private GameObject _currentPrefab;
    private GameObject _rival;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CapsuleCollider2D>())
        {
            _rival = collision.gameObject;
            InvokeRepeating("Fight", 1, 2);
            Debug.Log("onTriggerEnter");
        }
    }

    public override void StartFight(GameObject gameObject)
    {
        //_currentPrefab = Instantiate(_prefab, transform.position, Quaternion.identity);
        //_currentPrefab.GetComponent<Bullet>()._target = _rival;
    }

    public void Fight()
    {
        var pos = gameObject.GetComponentInChildren<GameObject>().transform.position;
        _currentPrefab = Instantiate(_prefab, pos, Quaternion.identity);
        Debug.Log(pos);
        _currentPrefab.GetComponent<Bullet>()._target = _rival;
    }
}
