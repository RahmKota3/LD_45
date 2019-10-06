using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Powerups { None, Mine, Boost, Bazooka, Shield }

public class PowerupController : MonoBehaviour
{
    Powerups currentPowerup = Powerups.None;

    public void RandomizePowerup()
    {
        currentPowerup = (Powerups)Random.Range(1, 5);
        Debug.Log(currentPowerup);
    }

    public void ActivatePowerup()
    {
        if (currentPowerup == Powerups.None)
            return;
    }
}
