using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public delegate void Empty();
    public event Empty Death;

    [SerializeField]
    private Text _healthText;

    [SerializeField]
    protected float _health;
    protected float _healthLevel;
    public void HealthChanges(float namber)
    {
        _healthLevel += namber;

        if (_healthLevel < 0)
        {

            Death?.Invoke();
            Destroy(gameObject);
        }
        else if (_healthLevel > _health)
        {
            _healthLevel = _health;
        }
        HealthRecord();

    }
    protected void SetHealthLevel()
    {
        _healthLevel = _health;
        HealthRecord();
    }
    protected virtual void HealthRecord()
    {
        if(_healthText!=null)
        _healthText.text = _healthLevel.ToString();
    }
    public float GetHealth() => _healthLevel / _health;
}
