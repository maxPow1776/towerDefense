using System.Collections;
using UnityEngine;

public class ConditionCollision : MonoBehaviour
{
    private string _isFight = "isFight";
    private string _isDie = "isDie";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerFighter>())
        {
            GetComponent<AutoMove>()._isCollision = true;
            gameObject.GetComponent<EnemyFighter>().StartFight(collision.gameObject);
            gameObject.GetComponent<Animator>().SetBool(_isFight, true);
        }
        if (collision.gameObject.GetComponent<MainTower>())
        {
            GetComponent<AutoMove>()._isCollision = true;
            gameObject.GetComponent<EnemyFighter>().StartFight(collision.gameObject);
            gameObject.GetComponent<Animator>().SetBool(_isFight, true);
            StartCoroutine(FightWithMainTower());
        }
    }

    IEnumerator FightWithMainTower()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.GetComponent<Animator>().SetBool(_isDie, true);
        Destroy(gameObject, 0.8f);
    }
}
