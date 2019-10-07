using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool CheckpointClear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && CheckpointClear == false)
            return;

        EntityStats e = other.gameObject.GetComponent<EntityStats>();
        
        if (e.CurrentLap < RaceManager.Instance.NumberOfLaps - 1)
            e.NewLap();
        else
            RaceManager.Instance.FinishedRace(other.gameObject);

        if (other.gameObject.tag == "Player")
            CheckpointClear = false;
    }
}
