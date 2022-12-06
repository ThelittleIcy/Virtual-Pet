using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "BehaviourPossibilities")]
public class ScriptablePossibilitie : ScriptableObject
{
    // Says, if the Possibilitie is already Maxed.
    public bool IsMaxed { get => m_isMaxed; set => m_isMaxed = value; }
    private bool m_isMaxed;
    // Says, if the Possibilitie is already at its Minimum.
    public bool IsMinimum { get => m_isMinimum; set => m_isMinimum = value; }
    private bool m_isMinimum;
    // The Possibility Value.
    public int Possibility
    {
        get => m_possibility;
        set
        {
            m_possibility = value;
            if(m_possibility >= 99)
            {
                m_possibility = 99;
                IsMaxed = true;
            }
            else if(m_possibility <= -1)
            {
                m_possibility = -1;
                IsMinimum = true;
            }
            else
            {
                IsMaxed = false;
                IsMinimum = false;
            }
        }
    }
    [SerializeField]
    [Range(-1, 99)]
    private int m_possibility = 50;
    // The Belonging Behaviour to this Possibilitie.
    public BehaviourEnum BelongingBehaviour { get => m_belongingBehaviour; set => m_belongingBehaviour = value; }
    [SerializeField]
    private BehaviourEnum m_belongingBehaviour;

    /// <summary>
    /// Increases the Possibilitie.
    /// </summary>
    /// <param name="_value">the value</param>
    public void Add(int _value)
    {
        if(IsMaxed == true)
        {
            Debug.Log("You tried to Increase A Possibility, that is already maxed");
            return;
        }
        Possibility = Possibility + _value;
    }
    /// <summary>
    /// Decreases the Possibilitie.
    /// </summary>
    /// <param name="_value">the value</param>
    public void Decrease(int _value)
    {
        if(IsMinimum == true)
        {
            Debug.Log("You tried to decrease A Possibility, that is already at it's minimum");
            return;
        }
        Possibility = Possibility - _value;
    }
    /// <summary>
    /// Sets the Possibilitie to its default value 50.
    /// </summary>
    public void SetToDefault()
    {
        Possibility = 50;
    }
}
