using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject _targetForBullet;
    [SerializeField] private float speed;
    private AbstractFighter _rival;
    [SerializeField] private Vector2 _force;
    public int damage;
    private string _isDie = "isDie";

    private void Update()
    {
        if (_targetForBullet != null)
            transform.position = Vector3.MoveTowards(transform.position, _targetForBullet.transform.position, Time.deltaTime * speed);
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyFighter>())
        {
            _rival = collision.gameObject.GetComponent<EnemyFighter>();
            _rival._health -= (damage - _rival._protection);
            if (_rival._hp != null)
                _rival._hp.GetComponent<Hp>()._health = _rival._health;
            Destroy(gameObject);
            if(_rival._health <= 0)
            {
                _rival.GetComponent<Animator>().SetBool(_isDie, true);
                if(_rival.GetComponent<EnemyFighter>()._placeForTower != null)
                    _rival.GetComponent<EnemyFighter>()._placeForTower.GetComponent<PutTower>()._hasEnemy = false;
                Destroy(collision.gameObject, 0.8f);
            }
        }
        if (collision.gameObject.GetComponent<TowerFighter>())
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
