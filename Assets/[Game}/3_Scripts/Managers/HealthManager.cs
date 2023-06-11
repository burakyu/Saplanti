using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int _currentHealth;

    private void OnEnable()
    {
        EventManager.PlayerTakeDamage.AddListener(ReduceHealth);
    }

    private void OnDisable()
    {
        EventManager.PlayerTakeDamage.RemoveListener(ReduceHealth);
    }

    private void Start()
    {
        _currentHealth = 3;
    }

    void ReduceHealth()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
        {

        }
        
    }
}
