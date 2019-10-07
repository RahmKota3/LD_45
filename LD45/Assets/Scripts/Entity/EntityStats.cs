using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    [HideInInspector] public int CurrentLap = 0;

    public bool IsStunned { get; private set; }
    float stunTime = 1.5f;
    float stunTimer = 0;

    public Action<int> OnLapFinished;

    AudioSource audioSource;

    public void NewLap()
    {
        CurrentLap += 1;

        OnLapFinished?.Invoke(CurrentLap);
    }

    public void Stun()
    {
        IsStunned = true;
        stunTimer = stunTime;

        SoundManager.Instance.PlayHitSound(audioSource);
    }
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
