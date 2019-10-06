using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    [HideInInspector] public int CurrentLap = 0;

    public bool IsStunned = false;
    float stunTime = 1.5f;
    float stunTimer = 0;

    public void Stun()
    {
        IsStunned = true;
        stunTimer = stunTime;
    }

    private void Update()
    {
        if(stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;

            if (stunTimer <= 0)
                IsStunned = false;
        }
        else
        {
            stunTimer = 0;
        }
    }
}
