using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Powerups { None, Mine, Boost, Bazooka, Shield }

public class PowerupController : MonoBehaviour
{
    Powerups currentPowerup = Powerups.None;

    [SerializeField] GameObject minePrefab;
    [SerializeField] GameObject boostObject;
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] GameObject shieldObject;

    [SerializeField] Transform mineLaunchPoint;
    [SerializeField] Transform rocketLaunchPoint;

    public void RandomizePowerup()
    {
        currentPowerup = (Powerups)Random.Range(1, 5);
        Debug.Log(currentPowerup);
    }

    public void ActivatePowerup()
    {
        if (currentPowerup == Powerups.None)
            return;

        switch (currentPowerup)
        {
            case Powerups.Mine:
                Instantiate(minePrefab, mineLaunchPoint.position, transform.rotation);
                break;
            case Powerups.Boost:
                boostObject.SetActive(true);
                break;
            case Powerups.Bazooka:
                Instantiate(rocketPrefab, rocketLaunchPoint.position, transform.rotation);
                break;
            case Powerups.Shield:
                shieldObject.SetActive(true);
                break;
        }
    }
}
