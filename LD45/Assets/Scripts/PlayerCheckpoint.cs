using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    GoalTrigger goalTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            goalTrigger.CheckpointClear = true;
    }

    private void Awake()
    {
        goalTrigger = FindObjectOfType<GoalTrigger>();
    }
}
