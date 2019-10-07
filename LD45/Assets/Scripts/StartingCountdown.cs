using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCountdown : MonoBehaviour
{
    [SerializeField] UI_Countdown uiCountdown;
    PauseMenuController pauseController;

    int roundedTime = 3;
    float time = 3;
    
    private void Update()
    {
        if (LevelManager.Instance.GetLevelName() == "Hub")
            return;

        int temp = roundedTime;

        time -= Time.deltaTime;
        roundedTime = Mathf.RoundToInt(time);

        if (temp != roundedTime)
        {
            uiCountdown.UpdateText(roundedTime);
            SoundManager.Instance.PlayCountdownSound();
        }

        if(roundedTime == 0)
        {
            uiCountdown.DisableText();
            RaceManager.Instance.StartMatch();
            this.enabled = false;
        }
    }
}
