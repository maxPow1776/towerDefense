using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : AbstractFighter
{
    private AbstractFighter _rival;
    private string _isFight = "isFight";
    public GameObject _zone;

    public override void StartFight(GameObject gameObject)
    {
        _rival = gameObject.GetComponent<AbstractFighter>();
        InvokeRepeating("Fight", 1, 2);
    }

    private void Fight()
    {
        try
        {
            if (_rival._health > 0 && _rival)
            {
                _rival._health -= (_damage - _rival._protection);
                Debug.Log("нанесен урон " + _rival._health);
            }
            else
            {
                _zone.GetComponent<ZoneEnter>().RemoveTowerFromZone(_rival.gameObject);
                Destroy(_rival.gameObject);
                CancelInvoke("Fight");
                GetComponent<AutoMove>()._isCollision = false;
                gameObject.GetComponent<Animator>().SetBool(_isFight, false);
            }
        } catch (MissingReferenceException e)
        {
            CancelInvoke("Fight");
            GetComponent<AutoMove>()._isCollision = false;
            gameObject.GetComponent<Animator>().SetBool(_isFight, false);
        }
    }
}
