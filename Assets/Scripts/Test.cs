using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    [SerializeField]
    public TMP_Text m_text;

    [SerializeField]
    public ScriptablePossibilitie m_pos;

    // Update is called once per frame
    void Update()
    {
        m_text.text = m_pos.Possibility.ToString() ;
    }
}
