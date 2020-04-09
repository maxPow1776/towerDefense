using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AbstractFighter
{
    public GameObject _targetForBullet;
    [SerializeField] private float speed;
    private AbstractFighter _rival;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetForBullet.transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CapsuleCollider2D>())
        { 
            _rival = gameObject.GetComponent<AbstractFighter>();
            StartFight(collision.gameObject);
        }
    }

    public override void StartFight(GameObject gameObject)
    {
        try
        {
            if (_rival._health > 0 && _rival)
                _rival._health -= (_damage - _rival._protection);
            else
            {
                Destroy(_rival.gameObject);
               
            }
            Destroy(gameObject);
            Debug.Log(_rival._health + "отняли злоровья у врага");
        }
        catch (MissingReferenceException e)
        {
            Destroy(gameObject);
        }
    }
}
