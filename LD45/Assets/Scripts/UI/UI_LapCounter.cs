using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_LapCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;

    void UpdateText(int lap)
    {
        txt.text = lap + " of " + RaceManager.Instance.NumberOfLaps.ToString();
    }

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>().OnLapFinished += UpdateText;

        UpdateText(0);
    }
}
