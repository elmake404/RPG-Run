using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : Health
{
    public AttackEnemy AttackEnemy { get; private set; }
    void Start()
    {
        AttackEnemy = GetComponent<AttackEnemy>();
        SetHealthLevel();
    }

    void Update()
    {

    }
}
