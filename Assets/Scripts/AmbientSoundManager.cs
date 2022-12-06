using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundManager : MonoBehaviour
{
    // List of the Different Ambient (Background) Sounds
    public List<AudioSource> AmbientSounds { get => m_ambientSounds; set => m_ambientSounds = value; }
    [SerializeField]
    private List<AudioSource> m_ambientSounds;

    // The Current Sound.
    private int m_current = 0;

    /// <summary>
    /// Playes the First Background Sound.
    /// </summary>
    private void Start()
    {
        AmbientSounds[m_current].Play();
    }
    /// <summary>
    /// Checks if the Currently played Ambient is still being played.
    ///     Increases to the next Sound or starts form the first again.
    /// </summary>
    private void Update()
    {
        if (!AmbientSounds[m_current].isPlaying)
        {
            m_current++;
            if(m_current > AmbientSounds.Count - 1)
            {
                m_current = 0;
            }
            AmbientSounds[m_current].Play();
        }
    }

}
