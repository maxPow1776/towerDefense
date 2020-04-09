using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEnter : MonoBehaviour
{
    private GameObject[] towers = new GameObject[3];
    

    public void AddTowerInZone(GameObject tower)
    {
        for(int i = 0; i < towers.Length; i++)
        {
            if(towers[i] == null)
            {
                towers[i] = tower;
                tower.GetComponent<TowerFighter>()._index = i;
                Debug.Log("башня довавлена в массив " + i);
                break;
            }
        }
    }

    public void RemoveTowerFromZone(GameObject tower)
    {
        Debug.Log("удаляем башню с индексом " + tower.GetComponent<TowerFighter>()._index);
        towers[tower.GetComponent<TowerFighter>()._index] = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyFighter>())
        {
            collision.gameObject.GetComponent<EnemyFighter>()._zone = this.gameObject;
            Debug.Log("вошел в коллизию и назачил зону врагу");
        }
        Debug.Log("вошел в коллизию");
    }


    /*[SerializeField] private GameObject _tower;
    private GameObject _rival;
    private bool _isLock = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CapsuleCollider2D>() && !_isLock)
        {
            _rival = collision.gameObject;
            _tower.GetComponent<TowerFighter>()._target = _rival;
            Debug.Log("вошел в область");
            _isLock = true;
        }
    }

    private void Update()
    {
        if (!_rival)
            _isLock = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CapsuleCollider2D>() && collision.gameObject == _rival)
        {
            _isLock = false;
        }
        Debug.Log("вышел из области");
    }*/
}
