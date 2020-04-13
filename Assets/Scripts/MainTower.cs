using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainTower : AbstractFighter
{
    [SerializeField] private GameObject _dotForHP;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _hpPrefab;
    [SerializeField] private Sprite _destroyedTower;

    public override void StartFight(GameObject gameObject)
    {
        
    }

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
        if(_health < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _destroyedTower;
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
