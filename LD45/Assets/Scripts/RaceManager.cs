using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance;

    [SerializeField] Transform CheckpointObj;
    public int NumberOfLaps = 1;

    [HideInInspector] public List<Transform> Checkpoints;

    public Action OnMatchStart;

    void GetCheckpoints()
    {
        foreach (Transform child in CheckpointObj)
        {
            Checkpoints.Add(child);
        }
    }

    private void Start()
    {
        // Todo: Add countdown to start.
        OnMatchStart?.Invoke();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        GetCheckpoints();
    }
}
