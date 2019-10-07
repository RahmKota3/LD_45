using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Running : MonoBehaviour
{
    NavMeshAgent agent;
    EntityStats stats;
    PowerupController powerupController;

    float normalSpeed;
    float boostedSpeed;
    float boostMultiplier = 2;

    List<Vector3> checkpointsLeft = new List<Vector3>();

    [SerializeField] float checkpointReachDistance = 5;

    void GetCheckpoints()
    {
        checkpointsLeft = AI_Checkpoint_Helper.Instance.Path;
    }

    void MatchStart()
    {
        agent.isStopped = false;
        agent.SetDestination(checkpointsLeft[0]);
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EntityStats>();
        powerupController = GetComponent<PowerupController>();

        normalSpeed = agent.speed;
        boostedSpeed = agent.speed * boostMultiplier;

        GetCheckpoints();

        RaceManager.Instance.OnRaceStart += MatchStart;
    }
    
    private void Update()
    {
        if (stats.IsStunned)
            agent.isStopped = true;
        else
            agent.isStopped = false;

        if (powerupController.BoostActive)
            agent.speed = boostedSpeed;
        else
            agent.speed = normalSpeed;

        if(checkpointsLeft.Count > 0)
        {
            if(Vector3.Distance(transform.position, checkpointsLeft[0]) <= checkpointReachDistance)
            {
                checkpointsLeft.RemoveAt(0);

                if(checkpointsLeft.Count > 0)
                    agent.SetDestination(checkpointsLeft[0]);
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
