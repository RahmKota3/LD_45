using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI_MusicSlider : MonoBehaviour
{
    public AudioMixer Mixer;

    public Slider SliderComponent;

    string MusicKeyName = "MusicVolume";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(MusicKeyName))
        {
            SliderComponent.value = PlayerPrefs.GetFloat(MusicKeyName);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(MusicKeyName))
        {
            SliderComponent.value = PlayerPrefs.GetFloat(MusicKeyName);
        }
    }

    public void OnVolumeSliderChange(float value)
    {
        Mixer.SetFloat("Volume", value);

        PlayerPrefs.SetFloat(MusicKeyName, value);
    }
}
