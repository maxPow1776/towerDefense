using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionCollision : MonoBehaviour
{
    private string _isFight = "isFight";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerFighter>() || collision.gameObject.GetComponent<MainTower>())
        {
            GetComponent<AutoMove>()._isCollision = true;
            gameObject.GetComponent<EnemyFighter>().StartFight(collision.gameObject);
            gameObject.GetComponent<Animator>().SetBool(_isFight, true);
        }
    }
}
