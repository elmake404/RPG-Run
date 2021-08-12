using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttak : Attack
{
    private PlayerLife _playerLife;
    private EnemyLife _targetEnemy;
    private PlayerMove _playerMove;
    private IEnumerator _attackCorotine;

    void Start()
    {
        _playerLife = GetComponent<PlayerLife>();
        _playerMove = GetComponent<PlayerMove>();
        _attackCorotine = AttackCorotine(null);
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (_targetEnemy == null)
        {
            _targetEnemy = other.GetComponent<EnemyLife>();
            if (_targetEnemy != null)
            {
                _targetEnemy.Death += StopAttack;
                StartAttack();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_targetEnemy?.gameObject == other.gameObject)
        {
            StopAttack();
            _targetEnemy = null;
        }
    }
    private void StartAttack()
    {
        _targetEnemy.AttackEnemy.StartAttack(_playerLife);

        StopCoroutine(_attackCorotine);
        _attackCorotine = AttackCorotine(_targetEnemy);
        StartCoroutine(_attackCorotine);

        _playerMove.IsStopped = true;
    }
    private void StopAttack()
    {
        _targetEnemy.Death -= StopAttack;

        StopCoroutine(_attackCorotine);
        _targetEnemy.AttackEnemy.StopAttack();

        _playerMove.IsStopped = false;
    }


}
