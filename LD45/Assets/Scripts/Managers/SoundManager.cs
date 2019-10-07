using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    AudioSource audioSource;
    
    [SerializeField] AudioClip pickupSound;
    [SerializeField] AudioClip boostSound;
    [SerializeField] AudioClip[] hitSounds;
    [SerializeField] AudioClip powerupUseSound;
    [SerializeField] AudioClip countdownSound;
    
    public void PlayPickupSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(pickupSound);
    }

    public void PlayBoostSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(boostSound);
    }
    
    public void PlayHitSound(AudioSource audioSource)
    {
        Debug.Log("hit");
        int rand = Random.Range(0, 2);
        audioSource.PlayOneShot(hitSounds[rand]);
    }
    
    public void PlayPowerupUseSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(powerupUseSound);
    }
    
    public void PlayCountdownSound()
    {
        audioSource.PlayOneShot(countdownSound);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        audioSource = GetComponent<AudioSource>();
    }
}
