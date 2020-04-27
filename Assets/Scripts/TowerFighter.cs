using System.Collections;
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
        if (Hp != null)
            Hp.GetComponent<Hp>()._health = Health;
    }

    public void Update()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
            _target = _enemies[i];
                if (!_isShoot)
                {
                    StartCoroutine(Shoot());
                }

            }
        }
    }

    IEnumerator Shoot()
    {
        _isShoot = true;
        yield return new WaitForSeconds(_interval);
        GameObject bullet = Instantiate(_prefab, gun.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>()._targetForBullet = _target;
        bullet.GetComponent<Bullet>().damage = Damage;
        _isShoot = false;
    }

    public void UpdateEnemies(GameObject[] gameObjects)
    {
        _enemies = gameObjects;
    }
}
