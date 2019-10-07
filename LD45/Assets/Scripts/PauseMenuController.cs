using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuObject;

    [SerializeField] PlayerRunningMovement player;

    bool isPaused = false;
    
    public void HardPause(bool pause)
    {
        Debug.Log(pause);
        if (isPaused)
        {
            player.enabled = false;
        }
        else
        {
            player.enabled = true;
        }
    }

    void PauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
            PauseGame();
        else
            UnpauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;

        pauseMenuObject.SetActive(isPaused);
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        pauseMenuObject.SetActive(isPaused);
    }

    private void Awake()
    {
        InputManager.Instance.OnPauseButtonPressed += PauseMenu;
    }
}
