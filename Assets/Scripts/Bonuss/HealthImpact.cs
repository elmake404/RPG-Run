using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthImpact : MonoBehaviour
{
    [SerializeField]
    private float _boostHealth;
    private void OnTriggerEnter(Collider other)
    {
        PlayerLife playerHealth = other.GetComponent<PlayerLife>();
        if (playerHealth != null)
        {
            playerHealth.HealthChanges(_boostHealth);
            Destroy(gameObject);
        }
    }
}
