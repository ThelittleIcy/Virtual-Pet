using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayThePossibilitie : MonoBehaviour
{
    // The Text Field.
    [SerializeField]
    public TMP_Text m_text;
    // The Possibilitie
    [SerializeField]
    public ScriptablePossibilitie m_pos;

    /// <summary>
    /// Updates the textfield.
    /// </summary>
    void Update()
    {
        m_text.text = m_pos.Possibility.ToString() ;
    }
}
