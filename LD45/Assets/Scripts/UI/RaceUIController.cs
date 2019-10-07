using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceUIController : MonoBehaviour
{
    [SerializeField] GameObject raceOverUI;
    [SerializeField] GameObject raceUI;

    void RaceOver()
    {
        raceUI.SetActive(false);
        raceOverUI.SetActive(true);
    }

    private void Awake()
    {
        RaceManager.Instance.OnRaceFinish += RaceOver;
    }
}
