using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private void OnEnable()
    {
        EventManager.PlayerFailed.AddListener(PlayerDied);
    }

    private void OnDisable()
    {
        EventManager.PlayerFailed.RemoveListener(PlayerDied);
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        HealthManager._currentHealth = 3;

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
