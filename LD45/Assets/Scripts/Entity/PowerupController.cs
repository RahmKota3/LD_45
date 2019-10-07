using System;
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

    public Action<Powerups> OnPowerupCollected;

    AudioSource audioSource;
    GameObject uiPowerup;
    
    public void RandomizePowerup()
    {
        currentPowerup = (Powerups)UnityEngine.Random.Range(1, 5);

        if (gameObject.tag == "Player")
            uiPowerup.SetActive(true);

        OnPowerupCollected?.Invoke(currentPowerup);
        SoundManager.Instance.PlayPickupSound(audioSource);
    }

    public void ActivatePowerup()
    {
        if (currentPowerup == Powerups.None)
            return;

        switch (currentPowerup)
        {
            case Powerups.Mine:
                UseMine();
                break;
            case Powerups.Boost:
                UseBoost();
                break;
            case Powerups.Bazooka:
                UseBazooka();
                break;
            case Powerups.Shield:
                UseShield();
                break;
        }

        OnPowerupCollected?.Invoke(currentPowerup);

        if(gameObject.tag == "Player")
            uiPowerup.SetActive(false);
    }

    void UseBoost()
    {
        boostObject.SetActive(true);
        BoostActive = true;
        powerupTimers[(int)currentPowerup] = powerupDuration;

        SoundManager.Instance.PlayBoostSound(audioSource);
    }

    void UseMine()
    {
        Instantiate(minePrefab, mineLaunchPoint.position, transform.rotation);
        currentPowerup = Powerups.None;

        SoundManager.Instance.PlayPowerupUseSound(audioSource);
    }

    void UseShield()
    {
        shieldObject.SetActive(true);
        ShieldActive = true;
        powerupTimers[(int)currentPowerup] = powerupDuration;

        SoundManager.Instance.PlayPowerupUseSound(audioSource);
    }

    void UseBazooka()
    {
        GameObject g = Instantiate(rocketPrefab, rocketLaunchPoint.position, transform.rotation);

        if (BoostActive)
            g.GetComponent<Rigidbody>().velocity *= 2;

        currentPowerup = Powerups.None;

        SoundManager.Instance.PlayPowerupUseSound(audioSource);
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
            GetComponent<AI_PowerupUse>().UsePowerup += ActivatePowerup;
        }
        else
        {
            InputManager.Instance.OnPowerupButtonPressed += ActivatePowerup;
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        GetPowerupInput();

        if (gameObject.tag == "Player" && LevelManager.Instance.GetLevelName() != "Hub")
        {
            uiPowerup = GameObject.FindGameObjectWithTag("PowerupDisplay");
            uiPowerup.SetActive(false);
        }
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

#region DEBUG
        if(Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                RandomizePowerup();
            }
        }
#endregion
    }
}
