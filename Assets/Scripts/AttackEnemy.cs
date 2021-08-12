using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Attack
{
    private PlayerLife _targetPlayer;
    private IEnumerator _attackCorotine;
    private void Start()
    {
        _attackCorotine = AttackCorotine(null);
    }
    public void StartAttack(PlayerLife target)
    {
        _targetPlayer = target;
        StopCoroutine(_attackCorotine);
        _attackCorotine = AttackCorotine(_targetPlayer);
        StartCoroutine(_attackCorotine);
    }
    public void StopAttack()
    {
        StopCoroutine(_attackCorotine);
        _targetPlayer = null;
    }
}
