using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private void OnEnable()
    {
        EventManager.PlayerFailed.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        EventManager.PlayerFailed.RemoveListener(RestartGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
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
