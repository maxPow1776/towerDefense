using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainTower : AbstractFighter
{
    [SerializeField] private GameObject _dotForHP;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _hpPrefab;
    [SerializeField] private Sprite _destroyedTower;
    [SerializeField] private GameObject _spawners;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private EnemyFighter[] _enemies;
    [SerializeField] private GameObject _spawnerManager;

    void Start()
    {
        var hp = Instantiate(_hpPrefab, Vector2.zero, Quaternion.identity);
        hp.transform.SetParent(_canvas.transform);
        _hp = hp;
        _hp.GetComponent<Hp>()._rectTransform.position = Camera.main.WorldToScreenPoint(_dotForHP.transform.position);
        _hp.GetComponent<Hp>()._fighter = gameObject;
        _hp.GetComponent<Hp>()._isMainTower = true;
        _hp.GetComponent<Text>().color = Color.green;
        _hp.GetComponent<Text>().fontSize = 30;
        if(_hp != null)
            _hp.GetComponent<Hp>()._health = _health;

    }

    void Update()
    {
        if(_health <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _destroyedTower;
            _spawners.SetActive(false);
            AbstractFighter[] _destroy = FindObjectsOfType<AbstractFighter>();
            foreach(AbstractFighter enemy in _destroy)
            {
                if(enemy._hp != null)
                    Destroy(enemy._hp);
            }
            foreach(EnemyFighter enemy in _enemies)
            {
                enemy.OnFirstWave();
            }
            _spawnerManager.GetComponent<SpawnerManager>().OnFirstWave();
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);      
        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
    }
}
