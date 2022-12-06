using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "String")]
public class ScriptableString : ScriptableObject
{
    // The Content.
    public string Content { get => m_content; set => m_content = value; }
    [SerializeField]
    private string m_content;
}
