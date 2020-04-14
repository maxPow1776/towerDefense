﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFighter : MonoBehaviour
{
    public int _firstHealth;
    public int _firstProtection;
    public int _firstDamage;
    public int _health;
    public int _protection;
    public int _damage;
    public GameObject _hp;

    public abstract void StartFight(GameObject gameObject);
}
