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

    public bool ShieldActive = false;
    public bool BoostActive = false;

    float powerupTimer = 0;
    
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
                currentPowerup = Powerups.None;
                break;
            case Powerups.Boost:
                boostObject.SetActive(true);
                BoostActive = true;
                break;
            case Powerups.Bazooka:
                Instantiate(rocketPrefab, rocketLaunchPoint.position, transform.rotation);
                currentPowerup = Powerups.None;
                break;
            case Powerups.Shield:
                shieldObject.SetActive(true);
                ShieldActive = true;
                break;
        }
    }

    void DisableActivePowerups()
    {
        currentPowerup = Powerups.None;

        BoostActive = false;
        ShieldActive = false;

        shieldObject.SetActive(false);
        boostObject.SetActive(false);
    }

    void GetPowerupInput()
    {
        AI_PowerupUse powerupInput1 = GetComponent<AI_PowerupUse>();

        if(powerupInput1 != null)
        {
            powerupInput1.OnPowerupUse += ActivatePowerup;
        }
    }

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (powerupTimer > 0)
        {
            powerupTimer -= Time.deltaTime;

            if (powerupTimer <= 0)
            {
                DisableActivePowerups();
            }
        }
        else
            powerupTimer = 0;
    }
}
