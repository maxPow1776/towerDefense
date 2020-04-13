using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : MonoBehaviour
{
    private int _waveNumber = 1;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private GameObject[] _spawners;
    [SerializeField] private GameObject _waveCountText;
    private int _countEnemies = 5;

    private void Start()
    {
        InvokeRepeating("NewWave", 60, 60);
        _waveCountText.GetComponent<Text>().text = _waveNumber.ToString();
    }

    public void NewWave()
    {
        _waveNumber += 1;
        _waveCountText.GetComponent<Text>().text = _waveNumber.ToString();
        if (_waveNumber % 5 == 0)
            _countEnemies++;
        for(int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].GetComponent<Spawner>()._countEnemies += _countEnemies;
        }
        ImproveEnemies();
    }

    public void ImproveEnemies()
    {
        for(int i = 0; i < _prefabs.Length; i++)
        {
            _prefabs[i].GetComponent<EnemyFighter>().NewLevelEnemy();
        }
    }
}
