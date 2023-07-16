using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Singleton<HealthManager>
{
    public static int _currentHealth;
    [SerializeField] private GameObject[] hearts;

    private void Awake()
    {
        if(Time.realtimeSinceStartup < 4) _currentHealth = 3;
    }

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
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i <_currentHealth) hearts[i].SetActive(true);
            else hearts[i].SetActive(false);
        }
    }

    void ReduceHealth()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
        {
            EventManager.PlayerFailed.Invoke();
            _currentHealth = 3;
            CoinManager.CoinCount = 0;
        }
        else
        {
            LevelManager.Instance.RestartLevel();
        }
        
    }
}
