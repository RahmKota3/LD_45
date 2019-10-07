using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySounds : MonoBehaviour
{
    [SerializeField] bool isACar = false;

    [SerializeField] AudioClip[] carSounds;
    [SerializeField] AudioClip manualMovmentSounds;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (isACar)
        {
            int rand = Random.Range(0, 2);
            audioSource.clip = carSounds[rand];
        }
        else
        {
            audioSource.clip = manualMovmentSounds;
        }

        audioSource.Play();
    }
}
