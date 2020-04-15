using UnityEngine;

public class ZoneEnter : MonoBehaviour
{
    private GameObject[] towers = new GameObject[3];
    [SerializeField] private GameObject[] enemies = new GameObject[10];

    public void AddTowerInZone(GameObject tower)
    {
        for(int i = 0; i < towers.Length; i++)
        {
            if(towers[i] == null)
            {
                towers[i] = tower;
                tower.GetComponent<TowerFighter>()._index = i;
                towers[i].GetComponent<TowerFighter>().UpdateEnemies(enemies);
                break;
            }
        }
    }

    public void RemoveTowerFromZone(GameObject tower)
    {
        towers[tower.GetComponent<TowerFighter>()._index] = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyFighter>())
        {
            collision.gameObject.GetComponent<EnemyFighter>()._zone = gameObject;
            for(int i = 0; i < enemies.Length; i++)
            {
                if(enemies[i] == null)
                {
                    enemies[i] = collision.gameObject;
                    for(int j = 0; j < towers.Length; j++)
                    {
                        if(towers[j] != null)
                            towers[j].GetComponent<TowerFighter>().UpdateEnemies(enemies);
                    }
                    break;
                }
            }
        }
    }
}
