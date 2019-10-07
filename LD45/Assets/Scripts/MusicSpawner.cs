using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpawner : MonoBehaviour
{
    [SerializeField] GameObject musicPlayerPrefab;

    private void Awake()
    {
        if (FindObjectOfType<MusicPlayer>() == null)
            Instantiate(musicPlayerPrefab, Vector3.zero, Quaternion.identity);
    }
}
