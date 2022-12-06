using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NamePet : MonoBehaviour
{
    // The Input Field fr the Name.
    [SerializeField]
    private TMP_InputField m_input;
    // The Name of the Pet.
    [SerializeField]
    private ScriptableString m_name;
    /// <summary>
    /// Updates the Name of the Pet.
    /// </summary>
    public void UpdateName()
    {
        m_name.Content = m_input.text.ToString();
    }
}
