using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceUIController : MonoBehaviour
{
    [SerializeField] GameObject raceOverUI;
    [SerializeField] GameObject raceUI;

    [SerializeField] TextMeshProUGUI txt;

    void RaceOver()
    {
        raceUI.SetActive(false);
        raceOverUI.SetActive(true);

        switch (RaceManager.Instance.PlayerPlace)
        {
            case 1:
                txt.text = "You placed 1st";
                break;
            case 2:
                txt.text = "You placed 2nd";
                break;
            case 3:
                txt.text = "You placed 3rd";
                break;
            default:
                txt.text = "You lost";
                break;
        }

        Time.timeScale = 0;
    }

    private void Awake()
    {
        RaceManager.Instance.OnRaceFinish += RaceOver;
    }
}
