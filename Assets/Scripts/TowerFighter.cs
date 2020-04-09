using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFighter : AbstractFighter
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject gun;
    private GameObject _currentPrefab;
    public GameObject _target;
    [SerializeField] private float _interval;
    private bool _isShoot = false;
    public int _index;

    public void Update()
    {
        if(_target)
        {
            if (!_isShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        _isShoot = true;
        yield return new WaitForSeconds(_interval);
        GameObject bullet = GameObject.Instantiate(_prefab, gun.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>()._targetForBullet = _target;
        _isShoot = false;
    }

    public override void StartFight(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }
}
