using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFighter : MonoBehaviour
{
    [SerializeField] public int _health;
    [SerializeField] public int _protection;
    [SerializeField] public int _damage;
    public GameObject _hp;

    public abstract void StartFight(GameObject gameObject);
}
