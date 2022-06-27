using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetChangeValue : MonoBehaviour
{
    [SerializeField]
    private ScriptableInt m_value;

    [SerializeField]
    private TMP_InputField m_field;

    public void Change()
    {
        if (int.TryParse(m_field.text, out int r))
        {
            m_value.Value = r;
        }
        else
        {
            Debug.LogError("Didn't gave a number");
        }
    }
}
