using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Checkpoint_Helper : MonoBehaviour
{
    public static AI_Checkpoint_Helper Instance;

    public List<Vector3> Path = new List<Vector3>();

    void SetUpCheckpointList()
    {
        int numOfCheckpoints = RaceManager.Instance.Checkpoints.Count + 1;

        foreach (Transform t in RaceManager.Instance.Checkpoints)
        {
            Path.Add(t.position);
        }
        Path.Add(GameObject.FindGameObjectWithTag("Goal").transform.position);

        for (int i = 0; i < RaceManager.Instance.NumberOfLaps - 1; i++)
        {
            for (int j = 0; j < numOfCheckpoints; j++)
            {
                Path.Add(Path[j]);
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        SetUpCheckpointList();
    }
}
