using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField]
    private int _price;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLife>()!=null)
        {
            PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")+_price);
            Destroy(gameObject);
        }
    }
}
