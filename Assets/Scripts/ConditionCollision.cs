using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider2D>())
        {
            GetComponent<AutoMove>()._collision = true;
            gameObject.GetComponent<EnemyFighter>().StartFight(collision.gameObject);
        }
    }
}
