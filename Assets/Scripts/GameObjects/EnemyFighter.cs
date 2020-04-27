using System.Collections;
using UnityEngine;

public class EnemyFighter : AbstractFighter
{
    private AbstractFighter _rival;
    private string _isFight = "isFight";

    public GameObject _zone;
    public GameObject _placeForTower;

    public int _firstHealth;
    public int _firstProtection;
    public int _firstDamage;

    private void Start()
    {
        if (Hp != null)
            Hp.GetComponent<Hp>()._health = Health;
    }

    public void StartFight(GameObject gameObject)
    {
        _rival = gameObject.GetComponent<AbstractFighter>();
        StartCoroutine(Fight());
    }

    IEnumerator Fight()
    {
        yield return new WaitForSeconds(1);
        try
        {
            if (_rival)
            {
                _rival.Health -= (Damage - _rival.Protection);
                var abstractFighter = _rival.GetComponent<AbstractFighter>();
                if(abstractFighter != null)
                {
                    var hp = abstractFighter.Hp.GetComponent<Hp>();
                    if (hp != null)
                    {
                        hp._health = _rival.Health;
                        if (_rival.Health <= 0)
                        {
                            if (_rival.GetComponent<TowerFighter>())
                                _zone.GetComponent<ZoneEnter>().RemoveTowerFromZone(_rival.gameObject);
                            Destroy(_rival.GetComponent<AbstractFighter>().Hp);
                            if (_rival.GetComponent<TowerFighter>())
                                Destroy(_rival.gameObject);
                            GetComponent<AutoMove>()._isCollision = false;
                            gameObject.GetComponent<Animator>().SetBool(_isFight, false);
                        } else
                        {
                            StartCoroutine(Fight());
                        }
                    }
                }  
            }
        } catch (MissingReferenceException e)
        {
            GetComponent<AutoMove>()._isCollision = false;
            gameObject.GetComponent<Animator>().SetBool(_isFight, false);
        }
    }

    public void NewLevelEnemy()
    {
        Health++;
        Damage++;
        Protection++;
    }

    public void OnFirstWave()
    {
        Health = _firstHealth;
        Protection = _firstProtection;
        Damage = _firstDamage;
    }
}
