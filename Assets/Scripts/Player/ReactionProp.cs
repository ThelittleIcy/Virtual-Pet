using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReactionProp : MonoBehaviour
{
    // Event for the Activation.
    public UnityEvent OnActivateEvent;
    // Event for the DeActivation.
    public UnityEvent OnDeactivateEvent;
    // Says, if the Prop is currently Used or not.
    public bool IsUsed { get => m_isUsed; set => m_isUsed = value; }
    [SerializeField]
    private bool m_isUsed;
    /// <summary>
    /// Sets IsUsed to true.
    /// </summary>
    public virtual void Activate()
    {
        IsUsed = true;
    }
    /// <summary>
    /// Sets IsUsed to false.
    /// </summary>
    public virtual void Deactivate()
    {
        IsUsed = false;
    }

}
