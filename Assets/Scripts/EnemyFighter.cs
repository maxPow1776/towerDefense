using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : AbstractFighter
{
    private AbstractFighter _rival;
    private string _isFight = "isFight";
    public GameObject _zone;
    public GameObject _placeForTower;

    private void Start()
    {
        if (_hp != null)
            _hp.GetComponent<Hp>()._health = _health;
    }

    public override void StartFight(GameObject gameObject)
    {
        _rival = gameObject.GetComponent<AbstractFighter>();
        InvokeRepeating("Fight", 1, 2);
    }

    private void Fight()
    {
        try
        {
            if (_rival)
            {
                _rival._health -= (_damage - _rival._protection);
                _rival.GetComponent<AbstractFighter>()._hp.GetComponent<Hp>()._health = _rival._health;
                if (_rival._health < 0)
                {
                    if(_rival.GetComponent<TowerFighter>())
                        _zone.GetComponent<ZoneEnter>().RemoveTowerFromZone(_rival.gameObject);
                    Destroy(_rival.GetComponent<AbstractFighter>()._hp);
                    if (_rival.GetComponent<TowerFighter>())
                        Destroy(_rival.gameObject);
                    CancelInvoke("Fight");
                    GetComponent<AutoMove>()._isCollision = false;
                    gameObject.GetComponent<Animator>().SetBool(_isFight, false);
                }
            }
        } catch (MissingReferenceException e)
        {
            CancelInvoke("Fight");
            GetComponent<AutoMove>()._isCollision = false;
            gameObject.GetComponent<Animator>().SetBool(_isFight, false);
        }
    }

    public void NewLevelEnemy()
    {
        _health += 1;
        _damage += 1;
        _protection += 1;
    }
}
