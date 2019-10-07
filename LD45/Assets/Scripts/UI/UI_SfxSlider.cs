using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI_SfxSlider : MonoBehaviour
{
    public AudioMixer Mixer;

    public Slider SliderComponent;

    string SfxKeyName = "SfxVolume";
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey(SfxKeyName))
        {
            SliderComponent.value = PlayerPrefs.GetFloat(SfxKeyName);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(SfxKeyName))
        {
            SliderComponent.value = PlayerPrefs.GetFloat(SfxKeyName);
        }
    }

    public void OnVolumeSliderChange(float value)
    {
        Mixer.SetFloat("Volume", value);

        PlayerPrefs.SetFloat(SfxKeyName, value);
    }
}
