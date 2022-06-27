using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundManager : MonoBehaviour
{
    public List<AudioSource> AmbientSounds { get => m_ambientSounds; set => m_ambientSounds = value; }
    [SerializeField]
    private List<AudioSource> m_ambientSounds;

    private int m_current = 0;


    private void Start()
    {
        AmbientSounds[m_current].Play();
    }
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
