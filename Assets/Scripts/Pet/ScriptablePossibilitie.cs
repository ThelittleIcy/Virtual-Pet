using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "BehaviourPossibilities")]
public class ScriptablePossibilitie : ScriptableObject
{
    public bool IsMaxed { get => m_isMaxed; set => m_isMaxed = value; }
    private bool m_isMaxed;
    public bool IsMinimum { get => m_isMinimum; set => m_isMinimum = value; }
    private bool m_isMinimum;

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
            else if(m_possibility <= 0)
            {
                m_possibility = 0;
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
    [Range(0, 99)]
    private int m_possibility = 50;


    public BehavoirEnum BelongingBehaviour { get => m_belongingBehaviour; set => m_belongingBehaviour = value; }
    [SerializeField]
    private BehavoirEnum m_belongingBehaviour;

    public void Add(int _value)
    {
        if(IsMaxed == true)
        {
            Debug.Log("You tried to Increase A Possibility, that is already maxed");
            return;
        }
        Possibility = Possibility + _value;
    }
    public void Decrease(int _value)
    {
        if(IsMinimum == true)
        {
            Debug.Log("You tried to decrease A Possibility, that is already at it's minimum");
            return;
        }
        Possibility = Possibility - _value;
    }

    public void SetToDefault()
    {
        Possibility = 50;
    }
}
