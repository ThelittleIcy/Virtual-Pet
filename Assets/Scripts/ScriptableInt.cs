using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data/Variables/Int", menuName =("Int"))]
public class ScriptableInt : ScriptableObject
{
    // The Value.
    public int Value { get => m_value; set => m_value = value; }
    [SerializeField]
    private int m_value;
}
