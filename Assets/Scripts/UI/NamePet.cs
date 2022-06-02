using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NamePet : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField m_input;
    [SerializeField]
    private ScriptableString m_name;
    public void UpdateName()
    {
        m_name.Content = m_input.text.ToString();
    }
}
