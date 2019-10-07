using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance;

    public Transform CheckpointObj;
    public int NumberOfLaps = 1;

    List<GameObject> podium = new List<GameObject>();

    [HideInInspector] public List<Transform> Checkpoints;

    public Action OnMatchStart;

    public void FinishedRace(GameObject entity)
    {
        podium.Add(entity);

        if (podium.Count == 3)
        {
            Debug.LogError("Match won: " + podium[0]);
            // Todo: On race finished stuff.
        }
    }

    void GetCheckpoints()
    {
        if(CheckpointObj == null)
        {
            Debug.Log("NO CHECKPOINT OBJECT!");
            return;
        }

        foreach (Transform child in CheckpointObj)
        {
            Checkpoints.Add(child);
        }
    }

    public void StartMatch()
    {
        OnMatchStart?.Invoke();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        GetCheckpoints();
    }
}
