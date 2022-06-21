using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Pet/Treasure", fileName = "ScriptableTreasure")]
public class ScriptableHiddenTreasure : ScriptableObject
{
    public Vector3 Postition { get => m_postition; set => m_postition = value; }
    [SerializeField]
    private Vector3 m_postition;

}
