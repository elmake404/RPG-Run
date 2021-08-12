using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float _attackPoswer, _attackSpeed;

    protected IEnumerator AttackCorotine(Health enemy)
    {
        while (true)
        {
            if (enemy != null)
                enemy.HealthChanges(-_attackPoswer);
            else
                break;

            yield return new WaitForSeconds(_attackSpeed);
        }
    }
    public void AttackChanges(float namber)
    {
        _attackPoswer += namber;
    }
}
