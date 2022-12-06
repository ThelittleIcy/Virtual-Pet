using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    // The AudioMixer.
    [SerializeField]
    private AudioMixer m_mixer;
    // Slider for the Master Volumne.
    [SerializeField]
    private Slider m_master;
    // Slider for the Backgroundmusic Volumne.
    [SerializeField]
    private Slider m_backgroundMusic;
    // Slider for the sfx Volumne.
    [SerializeField]
    private Slider m_sfx;
    // Names of the different Volumes saved in the Mixer.
    const string MIXER_MASTER = "MasterVolume";
    const string MIXER_BACKGROUND = "BackgroundVolume";
    const string MIXER_SFX = "SFXVolume";
    /// <summary>
    /// Adds listener to the OnValueChanged event of the differen Sliders.
    /// </summary>
    private void Awake()
    {
        m_master.onValueChanged.AddListener(SetMasterValue);
        m_backgroundMusic.onValueChanged.AddListener(SetBackgroundValue);
        m_sfx.onValueChanged.AddListener(SetSFXValue);
    }
    /// <summary>
    /// Sets the Master Volume Value.
    /// </summary>
    /// <param name="_value"></param>
    private void SetMasterValue(float _value)
    {
        m_mixer.SetFloat(MIXER_MASTER, Mathf.Log10(_value) * 20);
    }
    /// <summary>
    /// Sets the Background Music Volume Value.
    /// </summary>
    /// <param name="_value"></param>
    private void SetBackgroundValue(float _value)
    {
        m_mixer.SetFloat(MIXER_BACKGROUND, Mathf.Log10(_value) * 20);
    }
    /// <summary>
    /// Sets the SFX Volume Value.
    /// </summary>
    /// <param name="_value"></param>
    private void SetSFXValue(float _value)
    {
        m_mixer.SetFloat(MIXER_SFX, Mathf.Log10(_value) * 20);
    }
}
