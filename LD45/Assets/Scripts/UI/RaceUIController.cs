using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceUIController : MonoBehaviour
{
    [SerializeField] GameObject raceOverUI;
    [SerializeField] GameObject raceUI;

    [SerializeField]

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
