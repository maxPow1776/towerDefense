using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _interval;
    private bool _isCreating = false;
    [SerializeField] private GameObject _hp;
    [SerializeField] private GameObject _canvas;
    public int _countEnemies = 5;

    private void Start()
    {
        CreateEnemy();
        _countEnemies--;
    }

    private void Update()
    {
        if (!_isCreating && _countEnemies > 0) {
            StartCoroutine(CreateEnemyWithTimer());
            _countEnemies--;
        }
    }

    IEnumerator CreateEnemyWithTimer()
    {
        _isCreating = true;
        yield return new WaitForSeconds(_interval);
        CreateEnemy();
        _isCreating = false;
    }

    private void CreateEnemy()
    {
        var random = (int)(Random.value * 3);
        if (random == 3)
        {
            random = 0;
        }
        var enemy = Instantiate(_prefabs[random], transform.position, Quaternion.identity);
        var hp = Instantiate(_hp, Vector2.zero, Quaternion.identity);
        hp.transform.SetParent(_canvas.transform);
        hp.GetComponent<Hp>()._fighter = enemy;
        enemy.GetComponent<EnemyFighter>()._hp = hp;
    }
}
