using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackImpact : MonoBehaviour
{
    [SerializeField]
    private float _boostAttack;
    private void OnTriggerEnter(Collider other)
    {
        PlayerAttak playerAttak = other.GetComponent<PlayerAttak>();
        if (playerAttak!=null)
        {
            playerAttak.AttackChanges(_boostAttack);
            Destroy(gameObject);
        }
    }
}
