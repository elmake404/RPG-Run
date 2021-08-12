using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : Health
{
    [SerializeField]
    private Image _healthImage;
    void Start()
    {
        SetHealthLevel();
    }

    private void FixedUpdate()
    {
        if(_healthImage!=null)
        _healthImage.fillAmount = Mathf.Lerp(_healthImage.fillAmount,GetHealth(),0.2f);
    }
}
