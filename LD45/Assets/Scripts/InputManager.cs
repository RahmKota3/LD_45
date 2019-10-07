using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public Action OnPowerupButtonPressed;
    public Action OnPauseButtonPressed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Powerup"))
            OnPowerupButtonPressed?.Invoke();

        if (Input.GetButtonDown("Pause"))
            OnPauseButtonPressed?.Invoke();
    }
}
