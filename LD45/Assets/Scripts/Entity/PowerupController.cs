using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Powerups { None, Mine, Boost, Bazooka, Shield }

public class PowerupController : MonoBehaviour
{
    //Powerups currentPowerup = Powerups.None;
    Powerups currentPowerup = Powerups.Bazooka;

    [SerializeField] GameObject minePrefab;
    [SerializeField] GameObject boostObject;
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] GameObject shieldObject;

    [SerializeField] Transform mineLaunchPoint;
    [SerializeField] Transform rocketLaunchPoint;

    public bool ShieldActive = false;
    public bool BoostActive = false;
    
    float[] powerupTimers = new float[5];
    float powerupDuration = 3;
    
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
                powerupTimers[(int)currentPowerup] = powerupDuration;
                break;
            case Powerups.Bazooka:
                GameObject g =Instantiate(rocketPrefab, rocketLaunchPoint.position, transform.rotation);

                if (BoostActive)
                    g.GetComponent<Rigidbody>().velocity *= 2;
                
                currentPowerup = Powerups.None;
                break;
            case Powerups.Shield:
                shieldObject.SetActive(true);
                ShieldActive = true;
                powerupTimers[(int)currentPowerup] = powerupDuration;
                break;
        }
    }

    void DisableActivePowerups(Powerups pow)
    {
        currentPowerup = Powerups.None;

        switch (pow)
        {
            case Powerups.Boost:
                BoostActive = false;
                boostObject.SetActive(false);
                break;
            case Powerups.Shield:
                ShieldActive = false;
                shieldObject.SetActive(false);
                break;
        }
    }

    void GetPowerupInput()
    {
        if(gameObject.tag != "Player")
        {
            GetComponent<AI_PowerupUse>().OnPowerupUse += ActivatePowerup;
        }
        else
        {
            InputManager.Instance.OnPowerupButtonPressed += ActivatePowerup;
        }
    }

    private void Awake()
    {
        GetPowerupInput();
    }

    private void Update()
    {
        for (int i = 1; i < powerupTimers.Length; i++)
        {
            if (powerupTimers[i] > 0)
            {
                powerupTimers[i] -= Time.deltaTime;

                if (powerupTimers[i] <= 0)
                {
                    DisableActivePowerups((Powerups)i);
                }
            }
            else
                powerupTimers[i] = 0;
        }
    }
}
