using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public string GetLevelName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void GoToNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if(index < SceneManager.sceneCount)
            SceneManager.LoadScene(index + 1);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
