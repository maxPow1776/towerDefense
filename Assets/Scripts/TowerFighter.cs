using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFighter : AbstractFighter
{
    public GameObject _prefab;
    public GameObject gun;
    public float _interval;
    public GameObject _target;

    public int _index;

    private bool _isShoot = false;
    private GameObject[] _enemies = new GameObject[10];
    private GameObject _currentPrefab;

    private void Start()
    {
        if (_hp != null)
            _hp.GetComponent<Hp>()._health = _health;
    }

    public void Update()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                _target = _enemies[i];
                //while (_target != null)
                //{
                    if (!_isShoot)
                    {
                        StartCoroutine(Shoot());
                    }
                //}
            }
        }
    }

    IEnumerator Shoot()
    {
        _isShoot = true;
        yield return new WaitForSeconds(_interval);
        GameObject bullet = Instantiate(_prefab, gun.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>()._targetForBullet = _target;
        bullet.GetComponent<Bullet>().damage = _damage;
        _isShoot = false;
    }

    public override void StartFight(GameObject gameObject)
    {
        //_target = gameObject;
        //Debug.Log("Башня получила врага");
    }

    public void UpdateEnemies(GameObject[] gameObjects)
    {
        _enemies = gameObjects;
        Debug.Log("обновили в башне список врагов");
    }
}
