using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : AbstractFighter
{
    private AbstractFighter _rival;

    public override void StartFight(GameObject gameObject)
    {
        _rival = gameObject.GetComponent<AbstractFighter>();
        InvokeRepeating("Fight", 1, 2);
    }

    private void Fight()
    {
        if (_rival._health > 0)
            _rival._health -= (_damage - _rival._protection);
        else { 
            Destroy(_rival.gameObject);
            CancelInvoke("Fight");
            GetComponent<AutoMove>()._isCollision = false;
        }
        Debug.Log(_rival._health);
    }
}
