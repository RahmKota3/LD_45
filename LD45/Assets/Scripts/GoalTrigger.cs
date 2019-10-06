using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EntityStats e = other.gameObject.GetComponent<EntityStats>();
        if (e.CurrentLap < RaceManager.Instance.NumberOfLaps - 1)
            e.CurrentLap += 1;
        else
            RaceManager.Instance.FinishedRace(other.gameObject);
    }
}
