using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReactionProp : MonoBehaviour
{
    public UnityEvent OnActivateEvent;
    public UnityEvent OnDeactivateEvent;

    public bool IsUsed { get => m_isUsed; set => m_isUsed = value; }
    [SerializeField]
    private bool m_isUsed;

    public virtual void Activate()
    {
        IsUsed = true;
    }

    public virtual void Deactivate()
    {
        IsUsed = false;
    }

}
