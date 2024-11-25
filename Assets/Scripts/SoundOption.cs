using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider m_slider;
    public Slider b_slider;
    public Slider s_slider;

    private void Start() {
        m_slider.onValueChanged.AddListener(SoundManager.instance.MasterVolume);
        b_slider.onValueChanged.AddListener(SoundManager.instance.BGMVolume);
        s_slider.onValueChanged.AddListener(SoundManager.instance.SFXVolume);

        float m_volume;
        float b_volume;
        float s_volume;

        audioMixer.GetFloat("MasterVolume", out m_volume);
        audioMixer.GetFloat("BGMVolume", out b_volume);
        audioMixer.GetFloat("SFXVolume", out s_volume);

        m_slider.value = Mathf.Pow(10, m_volume / 20);
        b_slider.value = Mathf.Pow(10, b_volume / 20);
        s_slider.value = Mathf.Pow(10, s_volume / 20);
    }

    private void OnEnable() {
        
    }
}
