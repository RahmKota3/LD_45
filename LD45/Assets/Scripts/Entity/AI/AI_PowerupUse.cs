using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_PowerupUse : MonoBehaviour
{
    public Action UsePowerup;

    float timeBeforeUse = 5f;
    float timer = 0;

    void PowerupCollected(Powerups current)
    {
        timer = timeBeforeUse;
    }

    private void Awake()
    {
        GetComponent<PowerupController>().OnPowerupCollected += PowerupCollected;
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
                UsePowerup?.Invoke();
        }
        else
        {
            timer = 0;
        }
    }
}
